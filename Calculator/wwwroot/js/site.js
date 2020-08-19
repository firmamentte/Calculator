let isMathSignClicked = false

const formatNumber = (number) => {
    return isNaN(number) ? "" : number.toString().replace(/\B(?=(\d{3})+(?!\d))/g, '$&,')
}

const removeWhiteSpaceAndComma = (string) => {
    let _result = string.replace(/\,/g, '')
    _result = _result.replace(",", "")
    return _result
}

const serverNumberFormat = (number) => {
    return number.toString().split(',').join('')
}

const removeLineBreaks = (string) => {
    return string.replace(/\s{2,}/g, "")
}

const postOptions = (body) => {
    return {
        method: "POST",
        headers: {
            "Content-Type": "application/x-www-form-urlencoded; charset=UTF-8"
        },
        body: body
    }
}

const handleError = (response) => {

    if (!response.ok) {
        return response.text().
            then((error) => {
                throw Error(error)
            })
    }
    return response
}

const jsonDataType = (response) => {
    return response.json()
}

const enterNumber = (number) => {

    if (!!document.querySelector("#equalSign").textContent) {
        clearAll()
    }

    const _displayNumber = document.querySelector("#displayNumber"),
        _mathSign = document.querySelector("#mathSign")

    if (!(!!_mathSign.textContent)) {
        if (_displayNumber.value == 0) {
            _displayNumber.value = number
        } else {
            _displayNumber.value = formatNumber(`${removeWhiteSpaceAndComma(_displayNumber.value)}${number}`)
        }
    } else {
        if (isMathSignClicked) {
            _displayNumber.value = number
            isMathSignClicked = false
        } else {
            if (_displayNumber.value == 0) {
                _displayNumber.value = number
            } else {
                _displayNumber.value = formatNumber(`${removeWhiteSpaceAndComma(_displayNumber.value)}${number}`)
            }
        }
    }
}

const enterMathSign = (mathSign) => {

    isMathSignClicked = true

    document.querySelector("#number2").textContent = ""
    document.querySelector("#equalSign").textContent = ""
    document.querySelector("#number1").textContent = document.querySelector("#displayNumber").value
    document.querySelector("#mathSign").textContent = mathSign
}

const clearEntry = () => {
    document.querySelector("#displayNumber").value = "0"
}

const clearAll = () => {
    document.querySelector("#displayNumber").value = "0"
    document.querySelector("#number1").textContent = ""
    document.querySelector("#number2").textContent = ""
    document.querySelector("#mathSign").textContent = ""
    document.querySelector("#equalSign").textContent = ""
}

