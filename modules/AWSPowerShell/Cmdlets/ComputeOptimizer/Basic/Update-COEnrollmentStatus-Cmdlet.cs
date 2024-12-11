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
using Amazon.ComputeOptimizer;
using Amazon.ComputeOptimizer.Model;

namespace Amazon.PowerShell.Cmdlets.CO
{
    /// <summary>
    /// Updates the enrollment (opt in and opt out) status of an account to the Compute Optimizer
    /// service.
    /// 
    ///  
    /// <para>
    /// If the account is a management account of an organization, this action can also be
    /// used to enroll member accounts of the organization.
    /// </para><para>
    /// You must have the appropriate permissions to opt in to Compute Optimizer, to view
    /// its recommendations, and to opt out. For more information, see <a href="https://docs.aws.amazon.com/compute-optimizer/latest/ug/security-iam.html">Controlling
    /// access with Amazon Web Services Identity and Access Management</a> in the <i>Compute
    /// Optimizer User Guide</i>.
    /// </para><para>
    /// When you opt in, Compute Optimizer automatically creates a service-linked role in
    /// your account to access its data. For more information, see <a href="https://docs.aws.amazon.com/compute-optimizer/latest/ug/using-service-linked-roles.html">Using
    /// Service-Linked Roles for Compute Optimizer</a> in the <i>Compute Optimizer User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "COEnrollmentStatus", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ComputeOptimizer.Model.UpdateEnrollmentStatusResponse")]
    [AWSCmdlet("Calls the AWS Compute Optimizer UpdateEnrollmentStatus API operation.", Operation = new[] {"UpdateEnrollmentStatus"}, SelectReturnType = typeof(Amazon.ComputeOptimizer.Model.UpdateEnrollmentStatusResponse))]
    [AWSCmdletOutput("Amazon.ComputeOptimizer.Model.UpdateEnrollmentStatusResponse",
        "This cmdlet returns an Amazon.ComputeOptimizer.Model.UpdateEnrollmentStatusResponse object containing multiple properties."
    )]
    public partial class UpdateCOEnrollmentStatusCmdlet : AmazonComputeOptimizerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter IncludeMemberAccount
        /// <summary>
        /// <para>
        /// <para>Indicates whether to enroll member accounts of the organization if the account is
        /// the management account of an organization.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IncludeMemberAccounts")]
        public System.Boolean? IncludeMemberAccount { get; set; }
        #endregion
        
        #region Parameter Status
        /// <summary>
        /// <para>
        /// <para>The new enrollment status of the account.</para><para>The following status options are available:</para><ul><li><para><c>Active</c> - Opts in your account to the Compute Optimizer service. Compute Optimizer
        /// begins analyzing the configuration and utilization metrics of your Amazon Web Services
        /// resources after you opt in. For more information, see <a href="https://docs.aws.amazon.com/compute-optimizer/latest/ug/metrics.html">Metrics
        /// analyzed by Compute Optimizer</a> in the <i>Compute Optimizer User Guide</i>.</para></li><li><para><c>Inactive</c> - Opts out your account from the Compute Optimizer service. Your
        /// account's recommendations and related metrics data will be deleted from Compute Optimizer
        /// after you opt out.</para></li></ul><note><para>The <c>Pending</c> and <c>Failed</c> options cannot be used to update the enrollment
        /// status of an account. They are returned in the response of a request to update the
        /// enrollment status of an account.</para></note>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.ComputeOptimizer.Status")]
        public Amazon.ComputeOptimizer.Status Status { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ComputeOptimizer.Model.UpdateEnrollmentStatusResponse).
        /// Specifying the name of a property of type Amazon.ComputeOptimizer.Model.UpdateEnrollmentStatusResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Status), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-COEnrollmentStatus (UpdateEnrollmentStatus)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ComputeOptimizer.Model.UpdateEnrollmentStatusResponse, UpdateCOEnrollmentStatusCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.IncludeMemberAccount = this.IncludeMemberAccount;
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
            var request = new Amazon.ComputeOptimizer.Model.UpdateEnrollmentStatusRequest();
            
            if (cmdletContext.IncludeMemberAccount != null)
            {
                request.IncludeMemberAccounts = cmdletContext.IncludeMemberAccount.Value;
            }
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
        
        private Amazon.ComputeOptimizer.Model.UpdateEnrollmentStatusResponse CallAWSServiceOperation(IAmazonComputeOptimizer client, Amazon.ComputeOptimizer.Model.UpdateEnrollmentStatusRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Compute Optimizer", "UpdateEnrollmentStatus");
            try
            {
                #if DESKTOP
                return client.UpdateEnrollmentStatus(request);
                #elif CORECLR
                return client.UpdateEnrollmentStatusAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? IncludeMemberAccount { get; set; }
            public Amazon.ComputeOptimizer.Status Status { get; set; }
            public System.Func<Amazon.ComputeOptimizer.Model.UpdateEnrollmentStatusResponse, UpdateCOEnrollmentStatusCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
