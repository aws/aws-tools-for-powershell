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
using Amazon.IVS;
using Amazon.IVS.Model;

namespace Amazon.PowerShell.Cmdlets.IVS
{
    /// <summary>
    /// Performs <a>StartViewerSessionRevocation</a> on multiple channel ARN and viewer ID
    /// pairs simultaneously.
    /// </summary>
    [Cmdlet("Start", "IVSStartViewerSessionRevocation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IVS.Model.BatchStartViewerSessionRevocationError")]
    [AWSCmdlet("Calls the Amazon Interactive Video Service BatchStartViewerSessionRevocation API operation.", Operation = new[] {"BatchStartViewerSessionRevocation"}, SelectReturnType = typeof(Amazon.IVS.Model.BatchStartViewerSessionRevocationResponse))]
    [AWSCmdletOutput("Amazon.IVS.Model.BatchStartViewerSessionRevocationError or Amazon.IVS.Model.BatchStartViewerSessionRevocationResponse",
        "This cmdlet returns a collection of Amazon.IVS.Model.BatchStartViewerSessionRevocationError objects.",
        "The service call response (type Amazon.IVS.Model.BatchStartViewerSessionRevocationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StartIVSStartViewerSessionRevocationCmdlet : AmazonIVSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ViewerSession
        /// <summary>
        /// <para>
        /// <para>Array of viewer sessions, one per channel-ARN and viewer-ID pair.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("ViewerSessions")]
        public Amazon.IVS.Model.BatchStartViewerSessionRevocationViewerSession[] ViewerSession { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Errors'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IVS.Model.BatchStartViewerSessionRevocationResponse).
        /// Specifying the name of a property of type Amazon.IVS.Model.BatchStartViewerSessionRevocationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Errors";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ViewerSession), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-IVSStartViewerSessionRevocation (BatchStartViewerSessionRevocation)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IVS.Model.BatchStartViewerSessionRevocationResponse, StartIVSStartViewerSessionRevocationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.ViewerSession != null)
            {
                context.ViewerSession = new List<Amazon.IVS.Model.BatchStartViewerSessionRevocationViewerSession>(this.ViewerSession);
            }
            #if MODULAR
            if (this.ViewerSession == null && ParameterWasBound(nameof(this.ViewerSession)))
            {
                WriteWarning("You are passing $null as a value for parameter ViewerSession which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.IVS.Model.BatchStartViewerSessionRevocationRequest();
            
            if (cmdletContext.ViewerSession != null)
            {
                request.ViewerSessions = cmdletContext.ViewerSession;
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
        
        private Amazon.IVS.Model.BatchStartViewerSessionRevocationResponse CallAWSServiceOperation(IAmazonIVS client, Amazon.IVS.Model.BatchStartViewerSessionRevocationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Interactive Video Service", "BatchStartViewerSessionRevocation");
            try
            {
                #if DESKTOP
                return client.BatchStartViewerSessionRevocation(request);
                #elif CORECLR
                return client.BatchStartViewerSessionRevocationAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.IVS.Model.BatchStartViewerSessionRevocationViewerSession> ViewerSession { get; set; }
            public System.Func<Amazon.IVS.Model.BatchStartViewerSessionRevocationResponse, StartIVSStartViewerSessionRevocationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Errors;
        }
        
    }
}
