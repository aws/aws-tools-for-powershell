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
using System.Threading;
using Amazon.Pinpoint;
using Amazon.Pinpoint.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.PIN
{
    /// <summary>
    /// Creates an application.
    /// </summary>
    [Cmdlet("New", "PINApp", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Pinpoint.Model.ApplicationResponse")]
    [AWSCmdlet("Calls the Amazon Pinpoint CreateApp API operation.", Operation = new[] {"CreateApp"}, SelectReturnType = typeof(Amazon.Pinpoint.Model.CreateAppResponse))]
    [AWSCmdletOutput("Amazon.Pinpoint.Model.ApplicationResponse or Amazon.Pinpoint.Model.CreateAppResponse",
        "This cmdlet returns an Amazon.Pinpoint.Model.ApplicationResponse object.",
        "The service call response (type Amazon.Pinpoint.Model.CreateAppResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewPINAppCmdlet : AmazonPinpointClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CreateApplicationRequest_Name
        /// <summary>
        /// <para>
        /// <para>The display name of the application. This name is displayed as the <b>Project name</b>
        /// on the Amazon Pinpoint console.</para>
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
        public System.String CreateApplicationRequest_Name { get; set; }
        #endregion
        
        #region Parameter CreateApplicationRequest_Tag
        /// <summary>
        /// <para>
        /// <para>A string-to-string map of key-value pairs that defines the tags to associate with
        /// the application. Each tag consists of a required tag key and an associated tag value.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CreateApplicationRequest_Tags")]
        public System.Collections.Hashtable CreateApplicationRequest_Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ApplicationResponse'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Pinpoint.Model.CreateAppResponse).
        /// Specifying the name of a property of type Amazon.Pinpoint.Model.CreateAppResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ApplicationResponse";
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.CreateApplicationRequest_Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-PINApp (CreateApp)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Pinpoint.Model.CreateAppResponse, NewPINAppCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CreateApplicationRequest_Name = this.CreateApplicationRequest_Name;
            #if MODULAR
            if (this.CreateApplicationRequest_Name == null && ParameterWasBound(nameof(this.CreateApplicationRequest_Name)))
            {
                WriteWarning("You are passing $null as a value for parameter CreateApplicationRequest_Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.CreateApplicationRequest_Tag != null)
            {
                context.CreateApplicationRequest_Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.CreateApplicationRequest_Tag.Keys)
                {
                    context.CreateApplicationRequest_Tag.Add((String)hashKey, (System.String)(this.CreateApplicationRequest_Tag[hashKey]));
                }
            }
            
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
            var request = new Amazon.Pinpoint.Model.CreateAppRequest();
            
            
             // populate CreateApplicationRequest
            var requestCreateApplicationRequestIsNull = true;
            request.CreateApplicationRequest = new Amazon.Pinpoint.Model.CreateApplicationRequest();
            System.String requestCreateApplicationRequest_createApplicationRequest_Name = null;
            if (cmdletContext.CreateApplicationRequest_Name != null)
            {
                requestCreateApplicationRequest_createApplicationRequest_Name = cmdletContext.CreateApplicationRequest_Name;
            }
            if (requestCreateApplicationRequest_createApplicationRequest_Name != null)
            {
                request.CreateApplicationRequest.Name = requestCreateApplicationRequest_createApplicationRequest_Name;
                requestCreateApplicationRequestIsNull = false;
            }
            Dictionary<System.String, System.String> requestCreateApplicationRequest_createApplicationRequest_Tag = null;
            if (cmdletContext.CreateApplicationRequest_Tag != null)
            {
                requestCreateApplicationRequest_createApplicationRequest_Tag = cmdletContext.CreateApplicationRequest_Tag;
            }
            if (requestCreateApplicationRequest_createApplicationRequest_Tag != null)
            {
                request.CreateApplicationRequest.Tags = requestCreateApplicationRequest_createApplicationRequest_Tag;
                requestCreateApplicationRequestIsNull = false;
            }
             // determine if request.CreateApplicationRequest should be set to null
            if (requestCreateApplicationRequestIsNull)
            {
                request.CreateApplicationRequest = null;
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
        
        private Amazon.Pinpoint.Model.CreateAppResponse CallAWSServiceOperation(IAmazonPinpoint client, Amazon.Pinpoint.Model.CreateAppRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Pinpoint", "CreateApp");
            try
            {
                return client.CreateAppAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String CreateApplicationRequest_Name { get; set; }
            public Dictionary<System.String, System.String> CreateApplicationRequest_Tag { get; set; }
            public System.Func<Amazon.Pinpoint.Model.CreateAppResponse, NewPINAppCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ApplicationResponse;
        }
        
    }
}
