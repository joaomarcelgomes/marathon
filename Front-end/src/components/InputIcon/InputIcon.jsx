import './InputIcon.css'
import PropTypes from 'prop-types'

const InputIcon = ({ iconSrc, ...rest }) => {
  return (
    <div className="input-group">
      <span className="input-group-text background-custom border-0">
        <img src={iconSrc} alt="" />
      </span>
      <input
        className="form-control background-custom border-0 form-control-lg"
        {...rest}
      />
    </div>
  )
}

InputIcon.propTypes = {
  iconSrc: PropTypes.string.isRequired,
}

export default InputIcon
