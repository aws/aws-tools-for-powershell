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
using Amazon.ARCZonalShift;
using Amazon.ARCZonalShift.Model;

namespace Amazon.PowerShell.Cmdlets.AZS
{
    /// <summary>
    /// Update the status of autoshift observer notification. Autoshift observer notification
    /// enables you to be notified, through Amazon EventBridge, when there is an autoshift
    /// event for zonal autoshift.
    /// 
    ///  
    /// <para>
    /// If the status is <c>ENABLED</c>, ARC includes all autoshift events when you use the
    /// EventBridge pattern <c>Autoshift In Progress</c>. When the status is <c>DISABLED</c>,
    /// ARC includes only autoshift events for autoshifts when one or more of your resources
    /// is included in the autoshift.
    /// </para><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/r53recovery/latest/dg/arc-zonal-autoshift.how-it-works.html#ZAShiftNotification">
    /// Notifications for practice runs and autoshifts</a> in the Amazon Application Recovery
    /// Controller Developer Guide.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "AZSAutoshiftObserverNotificationStatus", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ARCZonalShift.AutoshiftObserverNotificationStatus")]
    [AWSCmdlet("Calls the AWS ARC - Zonal Shift UpdateAutoshiftObserverNotificationStatus API operation.", Operation = new[] {"UpdateAutoshiftObserverNotificationStatus"}, SelectReturnType = typeof(Amazon.ARCZonalShift.Model.UpdateAutoshiftObserverNotificationStatusResponse))]
    [AWSCmdletOutput("Amazon.ARCZonalShift.AutoshiftObserverNotificationStatus or Amazon.ARCZonalShift.Model.UpdateAutoshiftObserverNotificationStatusResponse",
        "This cmdlet returns an Amazon.ARCZonalShift.AutoshiftObserverNotificationStatus object.",
        "The service call response (type Amazon.ARCZonalShift.Model.UpdateAutoshiftObserverNotificationStatusResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateAZSAutoshiftObserverNotificationStatusCmdlet : AmazonARCZonalShiftClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Status
        /// <summary>
        /// <para>
        /// <para>The status to set for autoshift observer notification. If the status is <c>ENABLED</c>,
        /// ARC includes all autoshift events when you use the Amazon EventBridge pattern <c>Autoshift
        /// In Progress</c>. When the status is <c>DISABLED</c>, ARC includes only autoshift events
        /// for autoshifts when one or more of your resources is included in the autoshift. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.ARCZonalShift.AutoshiftObserverNotificationStatus")]
        public Amazon.ARCZonalShift.AutoshiftObserverNotificationStatus Status { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Status'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ARCZonalShift.Model.UpdateAutoshiftObserverNotificationStatusResponse).
        /// Specifying the name of a property of type Amazon.ARCZonalShift.Model.UpdateAutoshiftObserverNotificationStatusResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Status";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Status parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Status' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Status' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Status), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-AZSAutoshiftObserverNotificationStatus (UpdateAutoshiftObserverNotificationStatus)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ARCZonalShift.Model.UpdateAutoshiftObserverNotificationStatusResponse, UpdateAZSAutoshiftObserverNotificationStatusCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Status;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Status = this.Status;
            #if MODULAR
            if (this.Status == null && ParameterWasBound(nameof(this.Status)))
            {
                WriteWarning("You are passing $null as a value for parameter Status which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ARCZonalShift.Model.UpdateAutoshiftObserverNotificationStatusRequest();
            
            if (cmdletContext.Status != null)
            {
                request.Status = cmdletContext.Status;
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
        
        private Amazon.ARCZonalShift.Model.UpdateAutoshiftObserverNotificationStatusResponse CallAWSServiceOperation(IAmazonARCZonalShift client, Amazon.ARCZonalShift.Model.UpdateAutoshiftObserverNotificationStatusRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS ARC - Zonal Shift", "UpdateAutoshiftObserverNotificationStatus");
            try
            {
                #if DESKTOP
                return client.UpdateAutoshiftObserverNotificationStatus(request);
                #elif CORECLR
                return client.UpdateAutoshiftObserverNotificationStatusAsync(request).GetAwaiter().GetResult();
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
            public Amazon.ARCZonalShift.AutoshiftObserverNotificationStatus Status { get; set; }
            public System.Func<Amazon.ARCZonalShift.Model.UpdateAutoshiftObserverNotificationStatusResponse, UpdateAZSAutoshiftObserverNotificationStatusCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Status;
        }
        
    }
}
