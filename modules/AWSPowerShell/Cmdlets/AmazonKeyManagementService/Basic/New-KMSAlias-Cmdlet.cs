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
using Amazon.KeyManagementService;
using Amazon.KeyManagementService.Model;

namespace Amazon.PowerShell.Cmdlets.KMS
{
    /// <summary>
    /// Creates a display name for a customer master key. An alias can be used to identify
    /// a key and should be unique. The console enforces a one-to-one mapping between the
    /// alias and a key. An alias name can contain only alphanumeric characters, forward slashes
    /// (/), underscores (_), and dashes (-). An alias must start with the word "alias" followed
    /// by a forward slash (alias/). An alias that begins with "aws" after the forward slash
    /// (alias/aws...) is reserved by Amazon Web Services (AWS).
    /// 
    ///  
    /// <para>
    /// The alias and the key it is mapped to must be in the same AWS account and the same
    /// region.
    /// </para><para>
    /// To map an alias to a different key, call <a>UpdateAlias</a>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "KMSAlias", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Invokes the CreateAlias operation against AWS Key Management Service.", Operation = new[] {"CreateAlias"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the TargetKeyId parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.KeyManagementService.Model.CreateAliasResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewKMSAliasCmdlet : AmazonKeyManagementServiceClientCmdlet, IExecutor
    {
        
        #region Parameter AliasName
        /// <summary>
        /// <para>
        /// <para>String that contains the display name. The name must start with the word "alias" followed
        /// by a forward slash (alias/). Aliases that begin with "alias/AWS" are reserved.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String AliasName { get; set; }
        #endregion
        
        #region Parameter TargetKeyId
        /// <summary>
        /// <para>
        /// <para>An identifier of the key for which you are creating the alias. This value cannot be
        /// another alias but can be a globally unique identifier or a fully specified ARN to
        /// a key.</para><ul><li><para>Key ARN Example - arn:aws:kms:us-east-1:123456789012:key/12345678-1234-1234-1234-123456789012</para></li><li><para>Globally Unique Key ID Example - 12345678-1234-1234-1234-123456789012</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String TargetKeyId { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the TargetKeyId parameter.
        /// By default, this cmdlet does not generate any output.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter PassThru { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("TargetKeyId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-KMSAlias (CreateAlias)"))
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
            
            context.AliasName = this.AliasName;
            context.TargetKeyId = this.TargetKeyId;
            
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
            var request = new Amazon.KeyManagementService.Model.CreateAliasRequest();
            
            if (cmdletContext.AliasName != null)
            {
                request.AliasName = cmdletContext.AliasName;
            }
            if (cmdletContext.TargetKeyId != null)
            {
                request.TargetKeyId = cmdletContext.TargetKeyId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
                if (this.PassThru.IsPresent)
                    pipelineOutput = this.TargetKeyId;
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
        
        private Amazon.KeyManagementService.Model.CreateAliasResponse CallAWSServiceOperation(IAmazonKeyManagementService client, Amazon.KeyManagementService.Model.CreateAliasRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Key Management Service", "CreateAlias");
            try
            {
                #if DESKTOP
                return client.CreateAlias(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateAliasAsync(request);
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
            public System.String AliasName { get; set; }
            public System.String TargetKeyId { get; set; }
        }
        
    }
}
