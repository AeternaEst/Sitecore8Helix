import DisplayErrors from "./DisplayErrors";
import { connect } from "react-redux";

function mapStateToProps(state) {
  return {
    hasAvailabilityError: state.errors.availabilityError,
    cartIsUpdating: state.cartOverview.isUpdating
  };
}

const DisplayErrorsContainer = connect(mapStateToProps)(DisplayErrors);

export default DisplayErrorsContainer;
