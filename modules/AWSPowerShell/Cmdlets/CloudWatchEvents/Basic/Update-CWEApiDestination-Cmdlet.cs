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
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.CloudWatchEvents;
using Amazon.CloudWatchEvents.Model;

namespace Amazon.PowerShell.Cmdlets.CWE
{
    /// <summary>
    /// Updates an API destination.
    /// </summary>
    [Cmdlet("Update", "CWEApiDestination", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CloudWatchEvents.Model.UpdateApiDestinationResponse")]
    [AWSCmdlet("Calls the Amazon CloudWatch Events UpdateApiDestination API operation.", Operation = new[] {"UpdateApiDestination"}, SelectReturnType = typeof(Amazon.CloudWatchEvents.Model.UpdateApiDestinationResponse))]
    [AWSCmdletOutput("Amazon.CloudWatchEvents.Model.UpdateApiDestinationResponse",
        "This cmdlet returns an Amazon.CloudWatchEvents.Model.UpdateApiDestinationResponse object containing multiple properties."
    )]
    public partial class UpdateCWEApiDestinationCmdlet : AmazonCloudWatchEventsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ConnectionArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the connection to use for the API destination.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConnectionArn { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The name of the API destination to update.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter HttpMethod
        /// <summary>
        /// <para>
        /// <para>The method to use for the API destination.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CloudWatchEvents.ApiDestinationHttpMethod")]
        public Amazon.CloudWatchEvents.ApiDestinationHttpMethod HttpMethod { get; set; }
        #endregion
        
        #region Parameter InvocationEndpoint
        /// <summary>
        /// <para>
        /// <para>The URL to the endpoint to use for the API destination.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InvocationEndpoint { get; set; }
        #endregion
        
        #region Parameter InvocationRateLimitPerSecond
        /// <summary>
        /// <para>
        /// <para>The maximum number of invocations per second to send to the API destination.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? InvocationRateLimitPerSecond { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the API destination to update.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudWatchEvents.Model.UpdateApiDestinationResponse).
        /// Specifying the name of a property of type Amazon.CloudWatchEvents.Model.UpdateApiDestinationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Name parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CWEApiDestination (UpdateApiDestination)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudWatchEvents.Model.UpdateApiDestinationResponse, UpdateCWEApiDestinationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Name;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ConnectionArn = this.ConnectionArn;
            context.Description = this.Description;
            context.HttpMethod = this.HttpMethod;
            context.InvocationEndpoint = this.InvocationEndpoint;
            context.InvocationRateLimitPerSecond = this.InvocationRateLimitPerSecond;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CloudWatchEvents.Model.UpdateApiDestinationRequest();
            
            if (cmdletContext.ConnectionArn != null)
            {
                request.ConnectionArn = cmdletContext.ConnectionArn;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.HttpMethod != null)
            {
                request.HttpMethod = cmdletContext.HttpMethod;
            }
            if (cmdletContext.InvocationEndpoint != null)
            {
                request.InvocationEndpoint = cmdletContext.InvocationEndpoint;
            }
            if (cmdletContext.InvocationRateLimitPerSecond != null)
            {
                request.InvocationRateLimitPerSecond = cmdletContext.InvocationRateLimitPerSecond.Value;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
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
        
        private Amazon.CloudWatchEvents.Model.UpdateApiDestinationResponse CallAWSServiceOperation(IAmazonCloudWatchEvents client, Amazon.CloudWatchEvents.Model.UpdateApiDestinationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch Events", "UpdateApiDestination");
            try
            {
                #if DESKTOP
                return client.UpdateApiDestination(request);
                #elif CORECLR
                return client.UpdateApiDestinationAsync(request).GetAwaiter().GetResult();
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
            public System.String ConnectionArn { get; set; }
            public System.String Description { get; set; }
            public Amazon.CloudWatchEvents.ApiDestinationHttpMethod HttpMethod { get; set; }
            public System.String InvocationEndpoint { get; set; }
            public System.Int32? InvocationRateLimitPerSecond { get; set; }
            public System.String Name { get; set; }
            public System.Func<Amazon.CloudWatchEvents.Model.UpdateApiDestinationResponse, UpdateCWEApiDestinationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
