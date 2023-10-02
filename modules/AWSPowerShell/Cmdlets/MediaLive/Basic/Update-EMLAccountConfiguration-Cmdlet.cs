/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.MediaLive;
using Amazon.MediaLive.Model;

namespace Amazon.PowerShell.Cmdlets.EML
{
    /// <summary>
    /// Update account configuration
    /// </summary>
    [Cmdlet("Update", "EMLAccountConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MediaLive.Model.AccountConfiguration")]
    [AWSCmdlet("Calls the AWS Elemental MediaLive UpdateAccountConfiguration API operation.", Operation = new[] {"UpdateAccountConfiguration"}, SelectReturnType = typeof(Amazon.MediaLive.Model.UpdateAccountConfigurationResponse))]
    [AWSCmdletOutput("Amazon.MediaLive.Model.AccountConfiguration or Amazon.MediaLive.Model.UpdateAccountConfigurationResponse",
        "This cmdlet returns an Amazon.MediaLive.Model.AccountConfiguration object.",
        "The service call response (type Amazon.MediaLive.Model.UpdateAccountConfigurationResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateEMLAccountConfigurationCmdlet : AmazonMediaLiveClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AccountConfiguration_KmsKeyId
        /// <summary>
        /// <para>
        /// Specifies the KMS key to use for all features
        /// that use key encryption. Specify the ARN of a KMS key that you have created. Or leave
        /// blank to use the key that MediaLive creates and manages for you.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String AccountConfiguration_KmsKeyId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AccountConfiguration'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MediaLive.Model.UpdateAccountConfigurationResponse).
        /// Specifying the name of a property of type Amazon.MediaLive.Model.UpdateAccountConfigurationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AccountConfiguration";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the AccountConfiguration_KmsKeyId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^AccountConfiguration_KmsKeyId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^AccountConfiguration_KmsKeyId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AccountConfiguration_KmsKeyId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-EMLAccountConfiguration (UpdateAccountConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MediaLive.Model.UpdateAccountConfigurationResponse, UpdateEMLAccountConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.AccountConfiguration_KmsKeyId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AccountConfiguration_KmsKeyId = this.AccountConfiguration_KmsKeyId;
            
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
            var request = new Amazon.MediaLive.Model.UpdateAccountConfigurationRequest();
            
            
             // populate AccountConfiguration
            var requestAccountConfigurationIsNull = true;
            request.AccountConfiguration = new Amazon.MediaLive.Model.AccountConfiguration();
            System.String requestAccountConfiguration_accountConfiguration_KmsKeyId = null;
            if (cmdletContext.AccountConfiguration_KmsKeyId != null)
            {
                requestAccountConfiguration_accountConfiguration_KmsKeyId = cmdletContext.AccountConfiguration_KmsKeyId;
            }
            if (requestAccountConfiguration_accountConfiguration_KmsKeyId != null)
            {
                request.AccountConfiguration.KmsKeyId = requestAccountConfiguration_accountConfiguration_KmsKeyId;
                requestAccountConfigurationIsNull = false;
            }
             // determine if request.AccountConfiguration should be set to null
            if (requestAccountConfigurationIsNull)
            {
                request.AccountConfiguration = null;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
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
        
        private Amazon.MediaLive.Model.UpdateAccountConfigurationResponse CallAWSServiceOperation(IAmazonMediaLive client, Amazon.MediaLive.Model.UpdateAccountConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Elemental MediaLive", "UpdateAccountConfiguration");
            try
            {
                #if DESKTOP
                return client.UpdateAccountConfiguration(request);
                #elif CORECLR
                return client.UpdateAccountConfigurationAsync(request).GetAwaiter().GetResult();
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
            public System.String AccountConfiguration_KmsKeyId { get; set; }
            public System.Func<Amazon.MediaLive.Model.UpdateAccountConfigurationResponse, UpdateEMLAccountConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AccountConfiguration;
        }
        
    }
}
