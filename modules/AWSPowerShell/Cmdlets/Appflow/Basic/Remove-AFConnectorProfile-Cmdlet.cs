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
using Amazon.Appflow;
using Amazon.Appflow.Model;

namespace Amazon.PowerShell.Cmdlets.AF
{
    /// <summary>
    /// Enables you to delete an existing connector profile.
    /// </summary>
    [Cmdlet("Remove", "AFConnectorProfile", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Appflow DeleteConnectorProfile API operation.", Operation = new[] {"DeleteConnectorProfile"}, SelectReturnType = typeof(Amazon.Appflow.Model.DeleteConnectorProfileResponse))]
    [AWSCmdletOutput("None or Amazon.Appflow.Model.DeleteConnectorProfileResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Appflow.Model.DeleteConnectorProfileResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RemoveAFConnectorProfileCmdlet : AmazonAppflowClientCmdlet, IExecutor
    {
        
        #region Parameter ConnectorProfileName
        /// <summary>
        /// <para>
        /// <para> The name of the connector profile. The name is unique for each <code>ConnectorProfile</code>
        /// in your account. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String ConnectorProfileName { get; set; }
        #endregion
        
        #region Parameter ForceDelete
        /// <summary>
        /// <para>
        /// <para> Indicates whether Amazon AppFlow should delete the profile, even if it is currently
        /// in use in one or more flows. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ForceDelete { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Appflow.Model.DeleteConnectorProfileResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ConnectorProfileName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ConnectorProfileName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ConnectorProfileName' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ConnectorProfileName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-AFConnectorProfile (DeleteConnectorProfile)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Appflow.Model.DeleteConnectorProfileResponse, RemoveAFConnectorProfileCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ConnectorProfileName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ConnectorProfileName = this.ConnectorProfileName;
            #if MODULAR
            if (this.ConnectorProfileName == null && ParameterWasBound(nameof(this.ConnectorProfileName)))
            {
                WriteWarning("You are passing $null as a value for parameter ConnectorProfileName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ForceDelete = this.ForceDelete;
            
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
            var request = new Amazon.Appflow.Model.DeleteConnectorProfileRequest();
            
            if (cmdletContext.ConnectorProfileName != null)
            {
                request.ConnectorProfileName = cmdletContext.ConnectorProfileName;
            }
            if (cmdletContext.ForceDelete != null)
            {
                request.ForceDelete = cmdletContext.ForceDelete.Value;
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
        
        private Amazon.Appflow.Model.DeleteConnectorProfileResponse CallAWSServiceOperation(IAmazonAppflow client, Amazon.Appflow.Model.DeleteConnectorProfileRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Appflow", "DeleteConnectorProfile");
            try
            {
                #if DESKTOP
                return client.DeleteConnectorProfile(request);
                #elif CORECLR
                return client.DeleteConnectorProfileAsync(request).GetAwaiter().GetResult();
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
            public System.String ConnectorProfileName { get; set; }
            public System.Boolean? ForceDelete { get; set; }
            public System.Func<Amazon.Appflow.Model.DeleteConnectorProfileResponse, RemoveAFConnectorProfileCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
