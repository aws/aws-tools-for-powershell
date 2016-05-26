/*******************************************************************************
 *  Copyright 2012-2013 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Retrieves the encrypted administrator password for the instances running Windows and optionally decrypts it.
    /// </summary>
    [Cmdlet("Get", "EC2PasswordData")]
    [OutputType("PasswordData", "string")]
    [AWSCmdlet("Invokes the GetPasswordData operation against Amazon Elastic Compute Cloud.", Operation = new [] {"GetPasswordData"})]
    [AWSCmdletOutput("PasswordData",
        "If -Decrypt or -PemFile are not specified, returns a string containing the encrypted password for later decryption.",
        "The service response (type Amazon.EC2.Model.GetPasswordDataResponse) is added to the cmdlet entry in the $AWSHistory stack."
    )]
    [AWSCmdletOutput("string", "If -Decrypt or -PemFile is specified, the decrypted password.")]
    public class GetEC2PasswordDataCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        #region Parameter InstanceId
        /// <summary>
        /// The ID of the instance for which to get the password.
        /// </summary>
        [Parameter(Position=0, ValueFromPipelineByPropertyName=true, Mandatory=true)]
        public System.String InstanceId { get; set; }
        #endregion

        #region Parameter Decrypt
        /// <summary>
        /// If set, the instance password is decrypted and emitted to the pipeline as a string. 
        /// </summary>
        [Parameter]
        public SwitchParameter Decrypt { get; set; }
        #endregion

        #region Parameter PemFile 
        /// <summary>
        /// <para>
        /// The name of a .pem file containing the key materials corresponding to the keypair
        /// used to launch the instance. This will be used to decrypt the password data. 
        /// </para>
        /// <para>
        /// If a .pem file is not specified and -Decrypt is set, the name of the keypair used 
        /// to launch the instance will be retrieved from EC2 and an attempt made to load the 
        /// keypair materials from the local store maintained by the AWS Toolkit for Visual Studio, 
        /// if installed.
        /// </para>
        /// <para>
        /// If -PemFile is specified, then -Decrypt is assumed.
        /// </para>
        /// </summary>
        [Parameter]
        public System.String PemFile { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
                              {
                                  Region = this.Region,
                                  Credentials = this.CurrentCredentials,
                                  InstanceId = this.InstanceId,
                                  Decrypt = this.Decrypt.IsPresent || !string.IsNullOrEmpty(this.PemFile),
                                  PemFile = this.PemFile
                              };

            // specifying a pem file implies the user wants the password decrypted

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

            var client = Client ?? CreateClient(context.Credentials, context.Region);
            CmdletOutput output;
            
            try
            {
                var response = CallAWSServiceOperation(client, request);

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
                            ? DecryptViaPemDiscovery(cmdletContext.InstanceId, response)
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
        /// <returns>The decrypted password</returns>
        string DecryptViaPemDiscovery(string instanceId, GetPasswordDataResponse passwordDataResponse)
        {
            string decryptedPassword = null;
            try
            {
                WriteVerbose(string.Format("Retrieving keyname from running instance {0}", instanceId));
                var request = new DescribeInstancesRequest();
                request.InstanceIds.Add(instanceId);
                var response = Client.DescribeInstances(request);
                string keyName = response.Reservations[0].Instances[0].KeyName;

                WriteVerbose(string.Format("Retrieved keyname {0}, decrypting password data", keyName));
                string accountSettingsKey = LookupAccountSettingsKey(this.CurrentCredentials.GetCredentials().AccessKey);
                if (string.IsNullOrEmpty(accountSettingsKey))
                    throw new InvalidOperationException("Unable to determine stored account settings from access key");

                if (ToolkitKeyPairHelper.DoesPrivateKeyExist(accountSettingsKey, this.Region.SystemName, keyName))
                {
                    string privateKey = ToolkitKeyPairHelper.GetPrivateKey(accountSettingsKey, this.Region.SystemName, keyName);
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
                using (var reader = new StreamReader(pemFile))
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
        /// <param name="accessKey"></param>
        /// <returns></returns>
        string LookupAccountSettingsKey(string accessKey)
        {
            var settings = PersistenceManager.Instance.GetSettings(SettingsConstants.RegisteredProfiles);
            if (settings != null)
            {
                return (from s in settings let storedAccessKey = s[SettingsConstants.AccessKeyField] 
                            where string.Equals(storedAccessKey, accessKey, StringComparison.OrdinalIgnoreCase) 
                            select s.UniqueKey)
                       .FirstOrDefault();
            }

            return null;
        }

        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }

        #endregion

        #region AWS Service Operation Call

        private static Amazon.EC2.Model.GetPasswordDataResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.GetPasswordDataRequest request)
        {
            return client.GetPasswordData(request);
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
                    using (var reader = new StreamReader(fullpath))
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
