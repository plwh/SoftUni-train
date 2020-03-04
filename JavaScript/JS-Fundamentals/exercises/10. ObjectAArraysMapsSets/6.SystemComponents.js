function solve(input) {
    let systems = [];

    for(let i = 0; i < input.length; i++) {
        let args = input[i].split('|').map(x => x.trim()).filter(x => x !== '');
        let systemName = args[0];
        let componentName = args[1];
        let subComponentName = args[2];

        let currSys = systems.find(x => x.name === systemName);
        if(currSys === undefined) {
            currSys = { name: systemName, components: []};
            systems.push(currSys);
        }

        let component = currSys.components.find(x => x.name === componentName);
        if(component === undefined) {
            component = {name: componentName, subComponents: []};
            currSys.components.push(component);
        }

        component.subComponents.push(subComponentName);
    }

    systems = Array.from(systems).sort(sortSystemByNameAndComponentsLength);
    for (let system of systems) {
        console.log(system.name);
        let components = system.components.sort(sortComponents);
        for (let component of components) {
            console.log(`|||${component.name}`);
            component.subComponents.forEach(x => console.log(`||||||${x}`));
        }
    }

    function sortComponents(a, b) {
        let subCompALength = a.subComponents.length;
        let subCompBLength = b.subComponents.length;

        if(subCompALength >= subCompBLength) {
            return -1;
        }

        return 1;
    }

    function sortSystemByNameAndComponentsLength(a, b) {
        let compALength = a.components.length;
        let compBLength = b.components.length;
        if (compALength < compBLength) {
            return 1;
        } else if (compALength > compBLength) {
            return -1;
        } else {
            let sysAName = a.name;
            let sysBName = b.name;
            if(sysAName < sysBName) {
                return -1;
            } else {
                return 1;
            }
        }
    }
}

solve (["SULS | Main Site | Home Page",
    "SULS | Main Site | Login Page",
    "SULS | Main Site | Register Page",
    "SULS | Judge Site | Login Page",
    "SULS | Judge Site | Submittion Page",
    "Lambda | CoreA | A23",
    "SULS | Digital Site | Login Page",
    "Lambda | CoreB | B24",
    "Lambda | CoreA | A24",
    "Lambda | CoreA | A25",
    "Lambda | CoreC | C4",
    "Indice | Session | Default Storage",
    "Indice | Session | Default Security"]);