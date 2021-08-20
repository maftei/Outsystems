using System;
using System.Collections;
using System.Data;
using OutSystems.HubEdition.RuntimePlatform;

namespace OutSystems.NssExtension {

	public interface IssExtension {

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ssInputPassword"></param>
		/// <param name="ssOutputPassword"></param>
		void MssEncryptPassword(string ssInputPassword, out string ssOutputPassword);

	} // IssExtension

} // OutSystems.NssExtension
