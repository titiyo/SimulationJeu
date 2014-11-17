using System.Collections.Generic;
using SimulationJeu.Behavior;
using SimulationJeu.Goal;
using SimulationJeu.ObjectItem;
using SimulationJeu.Observer;
using SimulationJeu.Zone;

namespace SimulationJeu.Personage
{
    public abstract class PersonageAbstract : ObserverAbstract
    {
        // Utilisé pour l'initialisation des objectifs par type de personnage
        protected int IndexOfDefaultGoalObject;
        protected int IndexOfDefaultGoalPosition;
        // Utilisé pour l'initialisation de la position de départ par type de personnage
        protected int DefaultPosition;
        // Information sur le personnage
        protected string Name;
        protected bool Ko;
        protected int Pv;
        protected int DefaultVisibility;
        protected ZoneAbstract Position;
        protected List<GoalAbstract> Goals;
        protected List<ObjectItemAbstract> Objects ;
        // Etat majo du personnage
        protected SubjectObservedAbstract GeneralStaff;
        // Donnée mise à jour par l'état major
        protected ModeEnum OperatingMode;
        // Comportement du personnage
        protected FightBehaviorAbstract FightBehavior;
        protected MoveBehaviorAbstract MoveBehavior;
        protected InteractionObjectBehaviorAbstract InteractionObjectBehavior;

        public PersonageAbstract(string name, SubjectObservedAbstract generalStaff, FightBehaviorAbstract fightBehavior, MoveBehaviorAbstract moveBehavior, InteractionObjectBehaviorAbstract interactionObjectBehavior)
        {
            Name = name;
            FightBehavior = fightBehavior;
            MoveBehavior = moveBehavior;
            InteractionObjectBehavior = interactionObjectBehavior;
            if (generalStaff != null)
            {
                GeneralStaff = generalStaff;
                GeneralStaff.Attach(this);
                OperatingMode = GeneralStaff.OperatingMode;
            }
            Goals = new List<GoalAbstract>();
            Objects = new List<ObjectItemAbstract>();
            DefaultVisibility = 1;
            Ko = false;
        }

        public override void Update()
        {
            OperatingMode = GeneralStaff.OperatingMode;
        }

        public abstract string Display();

        /*********************************************/
        /*      Get; set                             */
        /*********************************************/
        #region GET_SET

        public bool GetKo()
        {
            return Ko;
        }

        public void SetKo(bool ko)
        {
            Ko = ko;
        }

        public int GetDefaultPosition()
        {
            return DefaultPosition;
        }

        public int GetIndexOfDefaultGoalPosition()
        {
            return IndexOfDefaultGoalPosition;
        }

        public int GetIndexOfDefaultGoalObject()
        {
            return IndexOfDefaultGoalObject;
        }

        public int GetDefaultVisibility()
        {
            return DefaultVisibility;
        }

        public int GetPv()
        {
            return Pv;
        }

        public void SetPv(int pv)
        {
            Pv = pv;
        }

        public string GetName()
        {
            return Name;
        }

        public ZoneAbstract GetPosition()
        {
            return Position;
        }

        public void SetPosition(ZoneAbstract position)
        {
            Position = position;
        }

        public List<GoalAbstract> GetGoals()
        {
            return Goals;
        }

        public void AddGoal(GoalAbstract goal)
        {
            Goals.Add(goal);
        }

        public List<ObjectItemAbstract> GetObjects()
        {
            return Objects;
        }

        public void SetObject(ObjectItemAbstract obj)
        {
            Objects.Add(obj);
        }

        public void SetFightBehavior(FightBehaviorAbstract fightBehavior)
        {
            FightBehavior = fightBehavior;
        }

        public MoveBehaviorAbstract GetMoveBehavior()
        {
            return MoveBehavior;
        }

        public void SetMoveBehavior(MoveBehaviorAbstract moveBehavior)
        {
            MoveBehavior = moveBehavior;
        }

        public void SetInteractionObjectBehavior(InteractionObjectBehaviorAbstract interactionObjectBehavior)
        {
            InteractionObjectBehavior = interactionObjectBehavior;
        }

        public InteractionObjectBehaviorAbstract GetInteractionObjectBehavior()
        {
            return InteractionObjectBehavior;
        }

        #endregion
    }
}
