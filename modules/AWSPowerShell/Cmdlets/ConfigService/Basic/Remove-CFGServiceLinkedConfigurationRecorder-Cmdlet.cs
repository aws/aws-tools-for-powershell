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
using Amazon.ConfigService;
using Amazon.ConfigService.Model;

namespace Amazon.PowerShell.Cmdlets.CFG
{
    /// <summary>
    /// Deletes an existing service-linked configuration recorder.
    /// 
    ///  
    /// <para>
    /// This operation does not delete the configuration information that was previously recorded.
    /// You will be able to access the previously recorded information by using the <a href="https://docs.aws.amazon.com/config/latest/APIReference/API_GetResourceConfigHistory.html">GetResourceConfigHistory</a>
    /// operation, but you will not be able to access this information in the Config console
    /// until you have created a new service-linked configuration recorder for the same service.
    /// </para><note><para><b>The recording scope determines if you receive configuration items</b></para><para>
    /// The recording scope is set by the service that is linked to the configuration recorder
    /// and determines whether you receive configuration items (CIs) in the delivery channel.
    /// If the recording scope is internal, you will not receive CIs in the delivery channel.
    /// </para></note>
    /// </summary>
    [Cmdlet("Remove", "CFGServiceLinkedConfigurationRecorder", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.ConfigService.Model.DeleteServiceLinkedConfigurationRecorderResponse")]
    [AWSCmdlet("Calls the AWS Config DeleteServiceLinkedConfigurationRecorder API operation.", Operation = new[] {"DeleteServiceLinkedConfigurationRecorder"}, SelectReturnType = typeof(Amazon.ConfigService.Model.DeleteServiceLinkedConfigurationRecorderResponse))]
    [AWSCmdletOutput("Amazon.ConfigService.Model.DeleteServiceLinkedConfigurationRecorderResponse",
        "This cmdlet returns an Amazon.ConfigService.Model.DeleteServiceLinkedConfigurationRecorderResponse object containing multiple properties."
    )]
    public partial class RemoveCFGServiceLinkedConfigurationRecorderCmdlet : AmazonConfigServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ServicePrincipal
        /// <summary>
        /// <para>
        /// <para>The service principal of the Amazon Web Services service for the service-linked configuration
        /// recorder that you want to delete.</para>
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
        public System.String ServicePrincipal { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ConfigService.Model.DeleteServiceLinkedConfigurationRecorderResponse).
        /// Specifying the name of a property of type Amazon.ConfigService.Model.DeleteServiceLinkedConfigurationRecorderResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ServicePrincipal parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ServicePrincipal' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ServicePrincipal' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ServicePrincipal), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-CFGServiceLinkedConfigurationRecorder (DeleteServiceLinkedConfigurationRecorder)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ConfigService.Model.DeleteServiceLinkedConfigurationRecorderResponse, RemoveCFGServiceLinkedConfigurationRecorderCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ServicePrincipal;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ServicePrincipal = this.ServicePrincipal;
            #if MODULAR
            if (this.ServicePrincipal == null && ParameterWasBound(nameof(this.ServicePrincipal)))
            {
                WriteWarning("You are passing $null as a value for parameter ServicePrincipal which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.ConfigService.Model.DeleteServiceLinkedConfigurationRecorderRequest();
            
            if (cmdletContext.ServicePrincipal != null)
            {
                request.ServicePrincipal = cmdletContext.ServicePrincipal;
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
        
        private Amazon.ConfigService.Model.DeleteServiceLinkedConfigurationRecorderResponse CallAWSServiceOperation(IAmazonConfigService client, Amazon.ConfigService.Model.DeleteServiceLinkedConfigurationRecorderRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Config", "DeleteServiceLinkedConfigurationRecorder");
            try
            {
                #if DESKTOP
                return client.DeleteServiceLinkedConfigurationRecorder(request);
                #elif CORECLR
                return client.DeleteServiceLinkedConfigurationRecorderAsync(request).GetAwaiter().GetResult();
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
            public System.String ServicePrincipal { get; set; }
            public System.Func<Amazon.ConfigService.Model.DeleteServiceLinkedConfigurationRecorderResponse, RemoveCFGServiceLinkedConfigurationRecorderCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
