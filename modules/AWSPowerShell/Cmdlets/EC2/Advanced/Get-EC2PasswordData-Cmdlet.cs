/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
 *  Licensed under the Apache License, Version 2.0 (the "License"). You may not use
 *  this file except in compliance with the License. A copy of the License is located at
 *
 *  http://aws.amazon.com/apache2.0
 *
 *  or in the "license" file accompanying this file.
 *  This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
 *  CONDITIONS OF ANY KIND, either express or implied. See the License for the
 *  specific language governing permissions and limitations under the License.
 * *****************************************************************************
 *
 *  AWS Tools for Windows (TM) PowerShell (TM)
 *
 */

using System;
using System.Linq;
using System.Management.Automation;
using System.IO;
using Amazon.PowerShell.Common;
using Amazon.EC2.Model;
using Amazon.Runtime.Internal.Settings;
using Amazon.EC2;
using Amazon.Runtime;
using Amazon.Runtime.CredentialManagement.Internal;
using Amazon.Runtime.CredentialManagement;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// <para>
    /// Retrieves the encrypted administrator password for the instances running Windows and optionally decrypts it.
    /// </para>
    /// <para>
    /// When running on Windows with the desktop version of PowerShell if the -Decrypt switch is specified the cmdlet 
    /// can attempt to auto-discover the name of the keypair that was used to launch the instance, and inspects the 
    /// configuration store of the AWS Toolkit for Visual Studio to determine if the corresponding keypair data needed 
    /// to decrypt the password is available locally. If it is the password will be decrypted without needing to specify 
    /// the location of the Pem file.
    /// </para>
    /// <para>
    /// On platforms other than Windows, or when running PowerShell Core on Windows, the configuration store of the AWS
    /// Toolkit for Visual Studio is not available. In these situations the location of a Pem file containing the data 
    /// needed to decrypt the password can be supplied to the -PemFile parameter.
    /// </para>
    /// <para>
    /// Note that if the -PemFile parameter is supplied (on any platform), the cmdlet automatically assumes that -Decrypt
    /// is set.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "EC2PasswordData", DefaultParameterSetName = AutoInspectForPemFile)]
    [OutputType("PasswordData", "string")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud GetPasswordData API operation.", Operation = new[] { "GetPasswordData" })]
    [AWSCmdletOutput("PasswordData",
        "If -Decrypt or -PemFile are not specified, returns a string containing the encrypted password for later decryption.",
        "The service responses (type Amazon.EC2.Model.GetPasswordDataResponse) can be returned by specifying '-Select *'."
    )]
    [AWSCmdletOutput("string", "If -Decrypt or -PemFile is specified, the decrypted password.")]
    public class GetEC2PasswordDataCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        private const string AutoInspectForPemFile = "AutoInspectForPemFile";
        private const string ManuallySupplyPemFile = "ManuallySupplyPemFile";

        #region Parameter InstanceId
        /// <summary>
        /// The ID of the instance for which to get the password.
        /// </summary>
        [Parameter(Position=0, ValueFromPipelineByPropertyName=true, ParameterSetName = AutoInspectForPemFile, Mandatory=true)]
        [Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ParameterSetName = ManuallySupplyPemFile, Mandatory=true)]
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String InstanceId { get; set; }
        #endregion

        #region Parameter Decrypt
        /// <summary>
        /// <para>
        /// If specified the instance password is decrypted and emitted to the pipeline as a string. 
        /// </para>
        /// <para>
        /// <b>Note:</b> If the -Pem File parameter is used this switch is assumed to be set. It is included
        /// in both parameter sets for this cmdlet for legacy, non-breaking change reasons.
        /// </para>
        /// </summary>
        [Parameter(ParameterSetName = AutoInspectForPemFile, ValueFromPipelineByPropertyName = true)]
        [Parameter(ParameterSetName = ManuallySupplyPemFile, ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Decrypt { get; set; }
        #endregion

        #region Parameter PemFile 
        /// <summary>
        /// <para>
        /// The name of a .pem file containing the key materials corresponding to the keypair
        /// used to launch the instance. This will be used to decrypt the password data. 
        /// </para>
        /// <para>
        /// If -PemFile is specified, then -Decrypt is assumed.
        /// </para>
        /// </summary>
        [Parameter(ParameterSetName = ManuallySupplyPemFile, Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String PemFile { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                InstanceId = this.InstanceId,
                Decrypt = this.Decrypt.IsPresent
            };

            // specifying a pem file implies the user wants the password decrypted
            if (!string.IsNullOrEmpty(this.PemFile))
            {
                context.Decrypt = true;
                context.PemFile = PSHelpers.PSPathToAbsolute(this.SessionState.Path, this.PemFile.Trim());
            }

            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            var request = new GetPasswordDataRequest();
            
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
            }

            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            CmdletOutput output;
            
            try
            {
                var response = CallAWSServiceOperation(client, request);

                if (string.IsNullOrEmpty(response.PasswordData))
                {
                    var msg = string.Format(
                        "Password data is not yet available for instance {0}.\n\nPassword generation and encryption can sometimes take more than 30 minutes. Please wait at least 5 minutes after launching an instance before trying to retrieve the generated password.",
                        cmdletContext.InstanceId);
                    this.WriteWarning(msg);
                    return new CmdletOutput
                    {
                        ServiceResponse = response
                    };
                }

                if (!cmdletContext.Decrypt)
                {
                    output = new CmdletOutput
                    {
                        PipelineOutput = response.PasswordData,
                        ServiceResponse = response
                    };
                }
                else
                {
                    output = new CmdletOutput
                    {
                        PipelineOutput = string.IsNullOrEmpty(cmdletContext.PemFile)
                            ? DecryptViaPemDiscovery(cmdletContext.InstanceId, response, ProfileName, ProfileLocation)
                            : DecryptViaPemFile(cmdletContext.PemFile, response)
                    };
                }
            }
            catch (Exception e)
            {
                output = new CmdletOutput { ErrorResponse = e };
            }
            
            return output;
        }

        /// <summary>
        /// Retrieves the name of the keypair used on launch from the instance, then inspects
        /// the local AWS Toolkit store for matching account & keypair data before decrypting
        /// the password data.
        /// </summary>
        /// <param name="instanceId">The instance the user wants the password for</param>
        /// <param name="passwordDataResponse">Encrypted password data retrieved from the instance</param>
        /// <param name="profileLocation">The location of the ini-format credential file.</param>
        /// <returns>The decrypted password</returns>
        string DecryptViaPemDiscovery(string instanceId, GetPasswordDataResponse passwordDataResponse, string profileName, string profileLocation)
        {
            string decryptedPassword = null;
            try
            {
                WriteVerbose(string.Format("Retrieving keyname from running instance {0}", instanceId));
                var request = new DescribeInstancesRequest();
                request.InstanceIds.Add(instanceId);
                var response = CallAWSServiceOperation(Client, request);
                string keyName = response.Reservations[0].Instances[0].KeyName;

                WriteVerbose(string.Format("Retrieved keyname {0}, decrypting password data", keyName));
                string accountSettingsKey = LookupAccountSettingsKey(this._CurrentCredentials.GetCredentials().AccessKey, profileName, profileLocation);
                if (string.IsNullOrEmpty(accountSettingsKey))
                    throw new InvalidOperationException("Unable to determine stored account settings from access key");

                if (ToolkitKeyPairHelper.DoesPrivateKeyExist(accountSettingsKey, this._RegionEndpoint.SystemName, keyName))
                {
                    string privateKey = ToolkitKeyPairHelper.GetPrivateKey(accountSettingsKey, this._RegionEndpoint.SystemName, keyName);
                    decryptedPassword = passwordDataResponse.GetDecryptedPassword(privateKey);
                }
            }
            catch (Exception e)
            {
                this.ThrowTerminatingError(new ErrorRecord(e, "InvalidOperationException", ErrorCategory.InvalidOperation, this));
            }

            return decryptedPassword;
        }

        /// <summary>
        /// Loads the specified .pem file and uses it to decrypt the password data returned
        /// from the instance.
        /// </summary>
        /// <param name="pemFile">The full path to the .pem file to use</param>
        /// <param name="passwordDataResponse">Encrypted password data retrieved from the instance</param>
        /// <returns>The decrypted password</returns>
        string DecryptViaPemFile(string pemFile, GetPasswordDataResponse passwordDataResponse)
        {
            string decryptedPassword = null;
            try
            {
                if (!File.Exists(pemFile))
                    throw new ArgumentException("Specified .pem file does not exist");

                string privateKey = null;
                using (var fs = File.OpenRead(pemFile))
                using (var reader = new StreamReader(fs))
                {
                    privateKey = reader.ReadToEnd();
                }

                decryptedPassword = passwordDataResponse.GetDecryptedPassword(privateKey);
            }
            catch (Exception e)
            {
                this.ThrowTerminatingError(new ErrorRecord(e, "InvalidOperationException", ErrorCategory.InvalidOperation, this));
            }

            return decryptedPassword;
        }

        /// <summary>
        /// Walks the credentials store to find the matching account settings for the specified
        /// access key
        /// </summary>
        /// <param name="accessKey">Access key to serach by.</param>
        /// <param name="profileName">ProfileName to search by.</param>
        /// <param name="profileLocation">The location of the ini-format credential file.</param>
        /// <returns></returns>
        string LookupAccountSettingsKey(string accessKey, string profileName, string profileLocation)
        {
            CredentialProfile profile;
            if (string.IsNullOrEmpty(profileName))
            {
                // no profile name so go by the access key
                profile = SettingsStore.ListProfiles(profileLocation).Where(
                    p => p.CanCreateAWSCredentials && string.Equals(p.Options.AccessKey, accessKey, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
            }
            else
            {
                // use profile name since we have it
                SettingsStore.TryGetProfile(profileName, profileLocation, out profile);
            }

            if (profile != null)
                return CredentialProfileUtils.GetUniqueKey(profile);
            else
                return null;
        }

        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }

#endregion

#region AWS Service Operation Call

        private Amazon.EC2.Model.GetPasswordDataResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.GetPasswordDataRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon EC2", "GetPasswordData");

            try
            {
#if DESKTOP
                return client.GetPasswordData(request);
#elif CORECLR
                return client.GetPasswordDataAsync(request).GetAwaiter().GetResult();
#else
#error "Unknown build edition"
#endif
            }
            catch (AmazonServiceException exc)
            {
                var webException = exc.InnerException as System.Net.WebException;
                if (webException != null)
                {
                    throw new Exception(Utils.Common.FormatNameResolutionFailureMessage(client.Config, webException.Message), webException);
                }

                throw;
            }
        }

        private Amazon.EC2.Model.DescribeInstancesResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.DescribeInstancesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon EC2", "DescribeInstances");
#if DESKTOP
            return client.DescribeInstances(request);
#elif CORECLR
            return client.DescribeInstancesAsync(request).GetAwaiter().GetResult();
#else
#error "Unknown build edition"
#endif
        }

#endregion

        // temp copy of ec2 plugins helper code, until we can (perhaps) get it moved into
        // toolkit utils
        internal static class ToolkitKeyPairHelper
        {
            public static bool DoesPrivateKeyExist(string accountSettingsKey, string region, string keyPairName)
            {
                string fullpath = GetFullPath(accountSettingsKey, region, keyPairName);
                return File.Exists(fullpath);
            }

            public static string GetPrivateKey(string accountSettingsKey, string region, string keyPairName)
            {
                try
                {
                    string fullpath = GetFullPath(accountSettingsKey, region, keyPairName);
                    if (!File.Exists(fullpath))
                        return null;

                    string encryptedPrivateKey = null;
                    using (var fs = File.OpenRead(fullpath))
                    using (var reader = new StreamReader(fs))
                    {
                        encryptedPrivateKey = reader.ReadToEnd();
                    }

                    return UserCrypto.Decrypt(encryptedPrivateKey);
                }
                catch (Exception e)
                {
                    throw new InvalidOperationException("Failed to read private key from settings folder", e);
                }
            }

            static string GetFullPath(string accountId, string region, string keyPairName)
            {
                string keyLocation = GetDirectory(accountId, region, keyPairName);
                string fullpath = string.Format(@"{0}\{1}.pem.encrypted", keyLocation, keyPairName);
                return fullpath;
            }

            static string GetDirectory(string accountId, string region, string keyPairName)
            {
                string settingsFolder = PersistenceManager.GetSettingsStoreFolder();
                string keyLocation = string.Format(@"{0}\keypairs\{1}\{2}", settingsFolder, accountId, region);
                if (!Directory.Exists(keyLocation))
                    Directory.CreateDirectory(keyLocation);

                return keyLocation;
            }
        }

        internal class CmdletContext : ExecutorContext
        {
            public String InstanceId { get; set; }
            public bool Decrypt { get; set; }
            public string PemFile { get; set; }
        }
    }
}
