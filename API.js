class API
{
    static ID = "";
    static AsyncGet(dto, cb)
    {
        dto.Add("ID", API.ID);
        fetch('/DTP', {
            method: 'POST',
            headers: {
                'Accept': 'application/dto',
                'Content-Type': 'application/dto'
            },
            body: dto.toString()
        })
        .then(response => response.text())
        .then(response => {
            cb(new DTO(response))
        } );
    }
    static GetDE(de, cb)
    {
        var dto = new DTO("");
        dto.Add("LOAD_DE", de);
        this.AsyncGet(dto, (d)=>{
            cb(d.Get("element"));
        });
    }
}
class DTO
{
    dict = new Object();
    constructor(STRING)
    {
        if(STRING.startsWith("#"))
            STRING = STRING.substring(1);
        STRING.split("\n#").forEach(element => {
            var e = element.substring(element.indexOf(":") + 1);
            if(e != "")
                this.dict[element.split(":")[0]] = e;
        });
    }
    toString = function()
    {
        var s = "";
        for(var key in this.dict) {
          s += "\n#" + key + ":" + this.dict[key];
        }
        if(s == "")
        return "";
        return s.substring(1);
    }
    Add = function(key, value)
    {
        this.dict[key] = value;
    }
    Get = function(key)
    {
        return this.dict[key];
    }
}