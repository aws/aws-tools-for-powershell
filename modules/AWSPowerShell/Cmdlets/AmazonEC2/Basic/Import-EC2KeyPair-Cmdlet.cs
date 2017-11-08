/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Imports the public key from an RSA key pair that you created with a third-party tool.
    /// Compare this with <a>CreateKeyPair</a>, in which AWS creates the key pair and gives
    /// the keys to you (AWS keeps a copy of the public key). With ImportKeyPair, you create
    /// the key pair and give AWS just the public key. The private key is never transferred
    /// between you and AWS.
    /// 
    ///  
    /// <para>
    /// For more information about key pairs, see <a href="http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/ec2-key-pairs.html">Key
    /// Pairs</a> in the <i>Amazon Elastic Compute Cloud User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Import", "EC2KeyPair", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.ImportKeyPairResponse")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud ImportKeyPair API operation.", Operation = new[] {"ImportKeyPair"})]
    [AWSCmdletOutput("Amazon.EC2.Model.ImportKeyPairResponse",
        "This cmdlet returns a Amazon.EC2.Model.ImportKeyPairResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class ImportEC2KeyPairCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter KeyName
        /// <summary>
        /// <para>
        /// <para>A unique name for the key pair.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String KeyName { get; set; }
        #endregion
        
        #region Parameter PublicKeyMaterial
        /// <summary>
        /// <para>
        /// <para>The public key. For API calls, the text must be base64-encoded. For command line tools,
        /// base64 encoding is performed for you.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        public System.String PublicKeyMaterial { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("KeyName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Import-EC2KeyPair (ImportKeyPair)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.KeyName = this.KeyName;
            context.PublicKeyMaterial = this.PublicKeyMaterial;
            
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
            var request = new Amazon.EC2.Model.ImportKeyPairRequest();
            
            if (cmdletContext.KeyName != null)
            {
                request.KeyName = cmdletContext.KeyName;
            }
            if (cmdletContext.PublicKeyMaterial != null)
            {
                request.PublicKeyMaterial = cmdletContext.PublicKeyMaterial;
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
        
        private Amazon.EC2.Model.ImportKeyPairResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.ImportKeyPairRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud", "ImportKeyPair");
            try
            {
                #if DESKTOP
                return client.ImportKeyPair(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.ImportKeyPairAsync(request);
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
            public System.String KeyName { get; set; }
            public System.String PublicKeyMaterial { get; set; }
        }
        
    }
}
