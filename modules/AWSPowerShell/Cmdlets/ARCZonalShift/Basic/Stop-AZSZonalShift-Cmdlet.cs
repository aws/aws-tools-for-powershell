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
    /// Cancel a zonal shift in Amazon Route 53 Application Recovery Controller. To cancel
    /// the zonal shift, specify the zonal shift ID.
    /// 
    ///  
    /// <para>
    /// A zonal shift can be one that you've started for a resource in your Amazon Web Services
    /// account in an Amazon Web Services Region, or it can be a zonal shift started by a
    /// practice run with zonal autoshift. 
    /// </para>
    /// </summary>
    [Cmdlet("Stop", "AZSZonalShift", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ARCZonalShift.Model.CancelZonalShiftResponse")]
    [AWSCmdlet("Calls the AWS ARC - Zonal Shift CancelZonalShift API operation.", Operation = new[] {"CancelZonalShift"}, SelectReturnType = typeof(Amazon.ARCZonalShift.Model.CancelZonalShiftResponse))]
    [AWSCmdletOutput("Amazon.ARCZonalShift.Model.CancelZonalShiftResponse",
        "This cmdlet returns an Amazon.ARCZonalShift.Model.CancelZonalShiftResponse object containing multiple properties."
    )]
    public partial class StopAZSZonalShiftCmdlet : AmazonARCZonalShiftClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ZonalShiftId
        /// <summary>
        /// <para>
        /// <para>The internally-generated identifier of a zonal shift.</para>
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
        public System.String ZonalShiftId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ARCZonalShift.Model.CancelZonalShiftResponse).
        /// Specifying the name of a property of type Amazon.ARCZonalShift.Model.CancelZonalShiftResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ZonalShiftId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Stop-AZSZonalShift (CancelZonalShift)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ARCZonalShift.Model.CancelZonalShiftResponse, StopAZSZonalShiftCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ZonalShiftId = this.ZonalShiftId;
            #if MODULAR
            if (this.ZonalShiftId == null && ParameterWasBound(nameof(this.ZonalShiftId)))
            {
                WriteWarning("You are passing $null as a value for parameter ZonalShiftId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ARCZonalShift.Model.CancelZonalShiftRequest();
            
            if (cmdletContext.ZonalShiftId != null)
            {
                request.ZonalShiftId = cmdletContext.ZonalShiftId;
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
        
        private Amazon.ARCZonalShift.Model.CancelZonalShiftResponse CallAWSServiceOperation(IAmazonARCZonalShift client, Amazon.ARCZonalShift.Model.CancelZonalShiftRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS ARC - Zonal Shift", "CancelZonalShift");
            try
            {
                #if DESKTOP
                return client.CancelZonalShift(request);
                #elif CORECLR
                return client.CancelZonalShiftAsync(request).GetAwaiter().GetResult();
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
            public System.String ZonalShiftId { get; set; }
            public System.Func<Amazon.ARCZonalShift.Model.CancelZonalShiftResponse, StopAZSZonalShiftCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
