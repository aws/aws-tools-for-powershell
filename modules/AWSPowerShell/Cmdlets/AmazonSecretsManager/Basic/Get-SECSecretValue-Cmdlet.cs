/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.SecretsManager;
using Amazon.SecretsManager.Model;

namespace Amazon.PowerShell.Cmdlets.SEC
{
    /// <summary>
    /// Retrieves the contents of the encrypted fields <code>SecretString</code> or <code>SecretBinary</code>
    /// from the specified version of a secret, whichever contains content.
    /// 
    ///  
    /// <para><b>Minimum permissions</b></para><para>
    /// To run this command, you must have the following permissions:
    /// </para><ul><li><para>
    /// secretsmanager:GetSecretValue
    /// </para></li><li><para>
    /// kms:Decrypt - required only if you use a customer-managed AWS KMS key to encrypt the
    /// secret. You do not need this permission to use the account's default AWS managed CMK
    /// for Secrets Manager.
    /// </para></li></ul><para><b>Related operations</b></para><ul><li><para>
    /// To create a new version of the secret with different encrypted information, use <a>PutSecretValue</a>.
    /// </para></li><li><para>
    /// To retrieve the non-encrypted details for the secret, use <a>DescribeSecret</a>.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Get", "SECSecretValue")]
    [OutputType("Amazon.SecretsManager.Model.GetSecretValueResponse")]
    [AWSCmdlet("Calls the AWS Secrets Manager GetSecretValue API operation.", Operation = new[] {"GetSecretValue"})]
    [AWSCmdletOutput("Amazon.SecretsManager.Model.GetSecretValueResponse",
        "This cmdlet returns a Amazon.SecretsManager.Model.GetSecretValueResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetSECSecretValueCmdlet : AmazonSecretsManagerClientCmdlet, IExecutor
    {
        
        #region Parameter SecretId
        /// <summary>
        /// <para>
        /// <para>Specifies the secret containing the version that you want to retrieve. You can specify
        /// either the Amazon Resource Name (ARN) or the friendly name of the secret.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String SecretId { get; set; }
        #endregion
        
        #region Parameter VersionId
        /// <summary>
        /// <para>
        /// <para>Specifies the unique identifier of the version of the secret that you want to retrieve.
        /// If you specify this parameter then don't specify <code>VersionStage</code>. If you
        /// don't specify either a <code>VersionStage</code> or <code>VersionId</code> then the
        /// default is to perform the operation on the version with the <code>VersionStage</code>
        /// value of <code>AWSCURRENT</code>.</para><para>This value is typically a <a href="https://wikipedia.org/wiki/Universally_unique_identifier">UUID-type</a>
        /// value with 32 hexadecimal digits.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String VersionId { get; set; }
        #endregion
        
        #region Parameter VersionStage
        /// <summary>
        /// <para>
        /// <para>Specifies the secret version that you want to retrieve by the staging label attached
        /// to the version.</para><para>Staging labels are used to keep track of different versions during the rotation process.
        /// If you use this parameter then don't specify <code>VersionId</code>. If you don't
        /// specify either a <code>VersionStage</code> or <code>VersionId</code>, then the default
        /// is to perform the operation on the version with the <code>VersionStage</code> value
        /// of <code>AWSCURRENT</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String VersionStage { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.SecretId = this.SecretId;
            context.VersionId = this.VersionId;
            context.VersionStage = this.VersionStage;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.SecretsManager.Model.GetSecretValueRequest();
            
            if (cmdletContext.SecretId != null)
            {
                request.SecretId = cmdletContext.SecretId;
            }
            if (cmdletContext.VersionId != null)
            {
                request.VersionId = cmdletContext.VersionId;
            }
            if (cmdletContext.VersionStage != null)
            {
                request.VersionStage = cmdletContext.VersionStage;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
                };
            }
            catch (Exception e)
            {
                output = new CmdletOutput { ErrorResponse = e };
            }
            
            return output;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.SecretsManager.Model.GetSecretValueResponse CallAWSServiceOperation(IAmazonSecretsManager client, Amazon.SecretsManager.Model.GetSecretValueRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Secrets Manager", "GetSecretValue");
            try
            {
                #if DESKTOP
                return client.GetSecretValue(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.GetSecretValueAsync(request);
                return task.Result;
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
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public System.String SecretId { get; set; }
            public System.String VersionId { get; set; }
            public System.String VersionStage { get; set; }
        }
        
    }
}
