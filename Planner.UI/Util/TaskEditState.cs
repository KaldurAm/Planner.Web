using Planner.Shared.Models;
using System;
using System.Collections.Generic;

namespace Planner.UI.Util
{
    public class TaskEditState
    {
        public List<CardDTO> Tasks { get; private set; }

        public List<StatusDTO> StatusList { get; private set; }

        public IEnumerable<UserDTO> Users { get; private set; }

        public CardDTO Task { get; private set; }

        public bool IsOpen { get; private set; }

        public event Action OnChange;

        public void Init(List<CardDTO> tasks, List<StatusDTO> statuses)
        {
            this.Tasks = tasks;
            this.StatusList = statuses;
        }

        public void SetCards(List<CardDTO> tasks)
        {
            this.Tasks = tasks;
        }

        public void SetStatuses(List<StatusDTO> statuses)
        {
            this.StatusList = statuses;
        }

        public void Open(CardDTO task, IEnumerable<UserDTO> users)
        {
            IsOpen = true;
            Task = task;
            Users = users;
            StateChanged();
        }

        public void Close()
        {
            IsOpen = false;
            Task = null;
            Users = null;
            StateChanged();
        }

        public void Delete(CardDTO card)
        {
            Tasks.Remove(card);
        }

        private void StateChanged() => OnChange?.Invoke();
    }
}
