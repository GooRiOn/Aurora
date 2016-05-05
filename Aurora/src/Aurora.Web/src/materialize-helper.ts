export class MaterializeHelper
{
    static initializeDropdown(elemName: string)
    {
        $('').ready(() => {
            $(elemName).material_select();
        });
    }

    static initializeDatePicker(elemName: string)
    {
        $(elemName).pickadate({
            selectMonths: true, 
            selectYears: 15 
        });
    }
}