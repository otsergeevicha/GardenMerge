mergeInto(LibraryManager.library, {

  GetPlayerData: function () {
    myGameInstance.SendMessage('PlayerData', 'SetName', player.GetName());
    myGameInstance.SendMessage('PlayerData', 'SetPhoto', player.GetPhoto("medium"));
  },

});