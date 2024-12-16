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
using Amazon.ARCZonalShift;
using Amazon.ARCZonalShift.Model;

namespace Amazon.PowerShell.Cmdlets.AZS
{
    /// <summary>
    /// You start a zonal shift to temporarily move load balancer traffic away from an Availability
    /// Zone in an Amazon Web Services Region, to help your application recover immediately,
    /// for example, from a developer's bad code deployment or from an Amazon Web Services
    /// infrastructure failure in a single Availability Zone. You can start a zonal shift
    /// in Route 53 ARC only for managed resources in your Amazon Web Services account in
    /// an Amazon Web Services Region. Resources are automatically registered with Route 53
    /// ARC by Amazon Web Services services.
    /// 
    ///  
    /// <para>
    /// At this time, you can only start a zonal shift for Network Load Balancers and Application
    /// Load Balancers with cross-zone load balancing turned off.
    /// </para><para>
    /// When you start a zonal shift, traffic for the resource is no longer routed to the
    /// Availability Zone. The zonal shift is created immediately in Route 53 ARC. However,
    /// it can take a short time, typically up to a few minutes, for existing, in-progress
    /// connections in the Availability Zone to complete.
    /// </para><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/r53recovery/latest/dg/arc-zonal-shift.html">Zonal
    /// shift</a> in the Amazon Route 53 Application Recovery Controller Developer Guide.
    /// </para>
    /// </summary>
    [Cmdlet("Start", "AZSZonalShift", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ARCZonalShift.Model.StartZonalShiftResponse")]
    [AWSCmdlet("Calls the AWS ARC - Zonal Shift StartZonalShift API operation.", Operation = new[] {"StartZonalShift"}, SelectReturnType = typeof(Amazon.ARCZonalShift.Model.StartZonalShiftResponse))]
    [AWSCmdletOutput("Amazon.ARCZonalShift.Model.StartZonalShiftResponse",
        "This cmdlet returns an Amazon.ARCZonalShift.Model.StartZonalShiftResponse object containing multiple properties."
    )]
    public partial class StartAZSZonalShiftCmdlet : AmazonARCZonalShiftClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AwayFrom
        /// <summary>
        /// <para>
        /// <para>The Availability Zone (for example, <c>use1-az1</c>) that traffic is moved away from
        /// for a resource when you start a zonal shift. Until the zonal shift expires or you
        /// cancel it, traffic for the resource is instead moved to other Availability Zones in
        /// the Amazon Web Services Region.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String AwayFrom { get; set; }
        #endregion
        
        #region Parameter Comment
        /// <summary>
        /// <para>
        /// <para>A comment that you enter about the zonal shift. Only the latest comment is retained;
        /// no comment history is maintained. A new comment overwrites any existing comment string.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String Comment { get; set; }
        #endregion
        
        #region Parameter ExpiresIn
        /// <summary>
        /// <para>
        /// <para>The length of time that you want a zonal shift to be active, which Route 53 ARC converts
        /// to an expiry time (expiration time). Zonal shifts are temporary. You can set a zonal
        /// shift to be active initially for up to three days (72 hours).</para><para>If you want to still keep traffic away from an Availability Zone, you can update the
        /// zonal shift and set a new expiration. You can also cancel a zonal shift, before it
        /// expires, for example, if you're ready to restore traffic to the Availability Zone.</para><para>To set a length of time for a zonal shift to be active, specify a whole number, and
        /// then one of the following, with no space:</para><ul><li><para><b>A lowercase letter m:</b> To specify that the value is in minutes.</para></li><li><para><b>A lowercase letter h:</b> To specify that the value is in hours.</para></li></ul><para>For example: <c>20h</c> means the zonal shift expires in 20 hours. <c>120m</c> means
        /// the zonal shift expires in 120 minutes (2 hours).</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String ExpiresIn { get; set; }
        #endregion
        
        #region Parameter ResourceIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier for the resource that Amazon Web Services shifts traffic for. The identifier
        /// is the Amazon Resource Name (ARN) for the resource.</para><para>At this time, supported resources are Network Load Balancers and Application Load
        /// Balancers with cross-zone load balancing turned off.</para>
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
        public System.String ResourceIdentifier { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ARCZonalShift.Model.StartZonalShiftResponse).
        /// Specifying the name of a property of type Amazon.ARCZonalShift.Model.StartZonalShiftResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ResourceIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-AZSZonalShift (StartZonalShift)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ARCZonalShift.Model.StartZonalShiftResponse, StartAZSZonalShiftCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AwayFrom = this.AwayFrom;
            #if MODULAR
            if (this.AwayFrom == null && ParameterWasBound(nameof(this.AwayFrom)))
            {
                WriteWarning("You are passing $null as a value for parameter AwayFrom which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Comment = this.Comment;
            #if MODULAR
            if (this.Comment == null && ParameterWasBound(nameof(this.Comment)))
            {
                WriteWarning("You are passing $null as a value for parameter Comment which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ExpiresIn = this.ExpiresIn;
            #if MODULAR
            if (this.ExpiresIn == null && ParameterWasBound(nameof(this.ExpiresIn)))
            {
                WriteWarning("You are passing $null as a value for parameter ExpiresIn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ResourceIdentifier = this.ResourceIdentifier;
            #if MODULAR
            if (this.ResourceIdentifier == null && ParameterWasBound(nameof(this.ResourceIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ARCZonalShift.Model.StartZonalShiftRequest();
            
            if (cmdletContext.AwayFrom != null)
            {
                request.AwayFrom = cmdletContext.AwayFrom;
            }
            if (cmdletContext.Comment != null)
            {
                request.Comment = cmdletContext.Comment;
            }
            if (cmdletContext.ExpiresIn != null)
            {
                request.ExpiresIn = cmdletContext.ExpiresIn;
            }
            if (cmdletContext.ResourceIdentifier != null)
            {
                request.ResourceIdentifier = cmdletContext.ResourceIdentifier;
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
        
        private Amazon.ARCZonalShift.Model.StartZonalShiftResponse CallAWSServiceOperation(IAmazonARCZonalShift client, Amazon.ARCZonalShift.Model.StartZonalShiftRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS ARC - Zonal Shift", "StartZonalShift");
            try
            {
                #if DESKTOP
                return client.StartZonalShift(request);
                #elif CORECLR
                return client.StartZonalShiftAsync(request).GetAwaiter().GetResult();
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
            public System.String AwayFrom { get; set; }
            public System.String Comment { get; set; }
            public System.String ExpiresIn { get; set; }
            public System.String ResourceIdentifier { get; set; }
            public System.Func<Amazon.ARCZonalShift.Model.StartZonalShiftResponse, StartAZSZonalShiftCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
