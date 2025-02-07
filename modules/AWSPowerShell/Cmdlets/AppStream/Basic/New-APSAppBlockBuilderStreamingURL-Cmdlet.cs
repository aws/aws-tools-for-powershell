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
using Amazon.AppStream;
using Amazon.AppStream.Model;

namespace Amazon.PowerShell.Cmdlets.APS
{
    /// <summary>
    /// Creates a URL to start a create app block builder streaming session.
    /// </summary>
    [Cmdlet("New", "APSAppBlockBuilderStreamingURL", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.AppStream.Model.CreateAppBlockBuilderStreamingURLResponse")]
    [AWSCmdlet("Calls the Amazon AppStream CreateAppBlockBuilderStreamingURL API operation.", Operation = new[] {"CreateAppBlockBuilderStreamingURL"}, SelectReturnType = typeof(Amazon.AppStream.Model.CreateAppBlockBuilderStreamingURLResponse))]
    [AWSCmdletOutput("Amazon.AppStream.Model.CreateAppBlockBuilderStreamingURLResponse",
        "This cmdlet returns an Amazon.AppStream.Model.CreateAppBlockBuilderStreamingURLResponse object containing multiple properties."
    )]
    public partial class NewAPSAppBlockBuilderStreamingURLCmdlet : AmazonAppStreamClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AppBlockBuilderName
        /// <summary>
        /// <para>
        /// <para>The name of the app block builder.</para>
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
        public System.String AppBlockBuilderName { get; set; }
        #endregion
        
        #region Parameter Validity
        /// <summary>
        /// <para>
        /// <para>The time that the streaming URL will be valid, in seconds. Specify a value between
        /// 1 and 604800 seconds. The default is 3600 seconds.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? Validity { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AppStream.Model.CreateAppBlockBuilderStreamingURLResponse).
        /// Specifying the name of a property of type Amazon.AppStream.Model.CreateAppBlockBuilderStreamingURLResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AppBlockBuilderName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-APSAppBlockBuilderStreamingURL (CreateAppBlockBuilderStreamingURL)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AppStream.Model.CreateAppBlockBuilderStreamingURLResponse, NewAPSAppBlockBuilderStreamingURLCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AppBlockBuilderName = this.AppBlockBuilderName;
            #if MODULAR
            if (this.AppBlockBuilderName == null && ParameterWasBound(nameof(this.AppBlockBuilderName)))
            {
                WriteWarning("You are passing $null as a value for parameter AppBlockBuilderName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Validity = this.Validity;
            
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
            var request = new Amazon.AppStream.Model.CreateAppBlockBuilderStreamingURLRequest();
            
            if (cmdletContext.AppBlockBuilderName != null)
            {
                request.AppBlockBuilderName = cmdletContext.AppBlockBuilderName;
            }
            if (cmdletContext.Validity != null)
            {
                request.Validity = cmdletContext.Validity.Value;
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
        
        private Amazon.AppStream.Model.CreateAppBlockBuilderStreamingURLResponse CallAWSServiceOperation(IAmazonAppStream client, Amazon.AppStream.Model.CreateAppBlockBuilderStreamingURLRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon AppStream", "CreateAppBlockBuilderStreamingURL");
            try
            {
                #if DESKTOP
                return client.CreateAppBlockBuilderStreamingURL(request);
                #elif CORECLR
                return client.CreateAppBlockBuilderStreamingURLAsync(request).GetAwaiter().GetResult();
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
            public System.String AppBlockBuilderName { get; set; }
            public System.Int64? Validity { get; set; }
            public System.Func<Amazon.AppStream.Model.CreateAppBlockBuilderStreamingURLResponse, NewAPSAppBlockBuilderStreamingURLCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
