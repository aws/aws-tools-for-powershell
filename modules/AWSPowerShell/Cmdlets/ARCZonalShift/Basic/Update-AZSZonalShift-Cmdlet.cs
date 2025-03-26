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
    /// Update an active zonal shift in Amazon Route 53 Application Recovery Controller in
    /// your Amazon Web Services account. You can update a zonal shift to set a new expiration,
    /// or edit or replace the comment for the zonal shift.
    /// </summary>
    [Cmdlet("Update", "AZSZonalShift", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ARCZonalShift.Model.UpdateZonalShiftResponse")]
    [AWSCmdlet("Calls the AWS ARC - Zonal Shift UpdateZonalShift API operation.", Operation = new[] {"UpdateZonalShift"}, SelectReturnType = typeof(Amazon.ARCZonalShift.Model.UpdateZonalShiftResponse))]
    [AWSCmdletOutput("Amazon.ARCZonalShift.Model.UpdateZonalShiftResponse",
        "This cmdlet returns an Amazon.ARCZonalShift.Model.UpdateZonalShiftResponse object containing multiple properties."
    )]
    public partial class UpdateAZSZonalShiftCmdlet : AmazonARCZonalShiftClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Comment
        /// <summary>
        /// <para>
        /// <para>A comment that you enter about the zonal shift. Only the latest comment is retained;
        /// no comment history is maintained. A new comment overwrites any existing comment string.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Comment { get; set; }
        #endregion
        
        #region Parameter ExpiresIn
        /// <summary>
        /// <para>
        /// <para>The length of time that you want a zonal shift to be active, which ARC converts to
        /// an expiry time (expiration time). Zonal shifts are temporary. You can set a zonal
        /// shift to be active initially for up to three days (72 hours).</para><para>If you want to still keep traffic away from an Availability Zone, you can update the
        /// zonal shift and set a new expiration. You can also cancel a zonal shift, before it
        /// expires, for example, if you're ready to restore traffic to the Availability Zone.</para><para>To set a length of time for a zonal shift to be active, specify a whole number, and
        /// then one of the following, with no space:</para><ul><li><para><b>A lowercase letter m:</b> To specify that the value is in minutes.</para></li><li><para><b>A lowercase letter h:</b> To specify that the value is in hours.</para></li></ul><para>For example: <c>20h</c> means the zonal shift expires in 20 hours. <c>120m</c> means
        /// the zonal shift expires in 120 minutes (2 hours).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExpiresIn { get; set; }
        #endregion
        
        #region Parameter ZonalShiftId
        /// <summary>
        /// <para>
        /// <para>The identifier of a zonal shift.</para>
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ARCZonalShift.Model.UpdateZonalShiftResponse).
        /// Specifying the name of a property of type Amazon.ARCZonalShift.Model.UpdateZonalShiftResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ZonalShiftId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ZonalShiftId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ZonalShiftId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ZonalShiftId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-AZSZonalShift (UpdateZonalShift)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ARCZonalShift.Model.UpdateZonalShiftResponse, UpdateAZSZonalShiftCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ZonalShiftId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Comment = this.Comment;
            context.ExpiresIn = this.ExpiresIn;
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
            var request = new Amazon.ARCZonalShift.Model.UpdateZonalShiftRequest();
            
            if (cmdletContext.Comment != null)
            {
                request.Comment = cmdletContext.Comment;
            }
            if (cmdletContext.ExpiresIn != null)
            {
                request.ExpiresIn = cmdletContext.ExpiresIn;
            }
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
        
        private Amazon.ARCZonalShift.Model.UpdateZonalShiftResponse CallAWSServiceOperation(IAmazonARCZonalShift client, Amazon.ARCZonalShift.Model.UpdateZonalShiftRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS ARC - Zonal Shift", "UpdateZonalShift");
            try
            {
                #if DESKTOP
                return client.UpdateZonalShift(request);
                #elif CORECLR
                return client.UpdateZonalShiftAsync(request).GetAwaiter().GetResult();
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
            public System.String Comment { get; set; }
            public System.String ExpiresIn { get; set; }
            public System.String ZonalShiftId { get; set; }
            public System.Func<Amazon.ARCZonalShift.Model.UpdateZonalShiftResponse, UpdateAZSZonalShiftCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
