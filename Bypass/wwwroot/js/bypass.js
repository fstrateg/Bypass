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
    $.ajax('/api/spremploee').
        done((rez) => {
            let staff = []
            rez.forEach((i) => staff.push({ label:i.name,value:i.id }))
            $('#staff').autocomplete({
                minLength: 2,
                source: staff,
                focus: function (event, ui) {
                    $("#staff").val(ui.item.label);
                    return false;
                },
                select: function (event, ui) {
                    $("#staff").val(ui.item.label);
                    $("#staff-vl").val(ui.item.value);
                    $("#caption").text(ui.item.label);

                    return false;
                },
                change: function (event, ui) {
                    if (ui.item == null) {
                        $("#staff").val('')
                        $("#staff-vl").val('');
                    }
                    return true;
                },
            })
        })
    $('input[name="event_date"]').datepicker({
        dateFormat: 'dd.mm.yy',
    })

}