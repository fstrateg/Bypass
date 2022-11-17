function load() {
    $.ajax('/api/sprevents')
        .done((rez) => {
            console.log(rez)
            let node = $('select[name="event"]').get(0)

            rez.forEach((i) => {
                let item = document.createElement("option")
                item.text = i.name
                item.setAttribute("key", i.id)
                node.appendChild(item)
            })
        })
    $('input[name="event_date"]').datepicker({
        dateFormat: 'dd.mm.yy',
    })
}