class ATable {
    Data = []
    TableClass = "undef"
    currentPage = 1
    lastPage = 1
    pageSize = 100
    footer = null
    node = null

    constructor(tbClass, data) {
        this.Data = data
        this.TableClass = tbClass
        this.node = $(this.TableClass + ' tbody')

        var table = this.node.get(0).parentNode
        var el = document.getElementsByClassName("tfooter")
        if (el.length == 0) {
            this.footer = document.createElement("div")
            this.footer.setAttribute("class", "tfooter")
            table.after(this.footer)
        }
        else {
            this.footer=el[0]
        }
       
    }

    drawData = function () {
        this.drawBody()
        this.drawFoter()
    }

    drawBody = function () {
        this.node.empty()
        var i = 1
        var b = (this.currentPage - 1) * this.pageSize
        var e = (this.currentPage * this.pageSize)
        this.Data.every(t => {
            
            if (i > e) return false;
            if (i > b) this.addRow(this.node, t)
            i++
            return true
        })
    }

    drawFoter() {
        var vl = "Страница {0} из {1}"
        this.lastPage = Math.round((this.Data.length) / this.pageSize)
        if (this.lastPage * this.pageSize < this.Data.length) this.lastPage++
        vl = vl.replace("{0}", this.currentPage)
            .replace("{1}", this.lastPage)
        this.footer.innerHTML = "<button class='abutton' onclick='document.atable.firstPage()'>&lt;&lt;</button>"
            +"<button class='abutton' onclick = 'document.atable.prevPage()' >&lt;</button>"
            + vl 
            +"<button class='abutton' onclick='document.atable.nextPage()'>&gt;</button>"
        +"<button class='abutton' onclick='document.atable.golastPage()'>&gt;&gt;</button>"
        
    }
    firstPage = function () {
        this.currentPage = 1
        this.drawData()
    }

    golastPage = function () {
        this.currentPage = this.lastPage
        this.drawData()
    }

    nextPage = function () {
        if (this.currentPage == this.lastPage) return
        this.currentPage++
        this.drawData()
    }

    prevPage = function () {
        if (this.currentPage==1) return
        this.currentPage--
        this.drawData()
    }

    addRow = function (el, row) {
        var tr = document.createElement("tr");
        var f = (val) => {
            var t = document.createElement("td");
            t.innerHTML = val
            tr.appendChild(t)
        }

        f(row.docDate)
        f(row.eventDate)
        f(row.event)
        f(row.fio)
        f(row.staff)
        f(row.remark)

        el.append(tr.outerHTML)
    }

}