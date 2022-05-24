function DeleteAvailability(ContractId) {
    document.getElementById("deleteContractId").value = ContractId;
    $('#ModalContractDelete').modal('show').find('.modal-title');
}