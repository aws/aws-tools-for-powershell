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
using Amazon.EC2;
using Amazon.EC2.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Replaces or removes the instance type specification for an AMI. The instance type
    /// specification defines which instance types are compatible with the AMI.
    /// 
    ///  
    /// <para>
    /// When you launch an instance using <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/API_RunInstances.html">RunInstances</a>,
    /// Amazon EC2 validates the requested instance type against the AMI's instance type specification.
    /// If the instance type is not compatible, the request fails with an <c>InvalidParameterCombination</c>
    /// error.
    /// </para><para>
    /// You can specify supported instance types, unsupported instance types, or both. The
    /// evaluation logic is as follows:
    /// </para><ul><li><para>
    /// No specification set – all instance types are allowed.
    /// </para></li><li><para>
    /// Only <c>UnsupportedInstanceTypes</c> set – All instance types are allowed except those
    /// that match the unsupported list.
    /// </para></li><li><para><c>SupportedInstanceTypes</c> set – The instance type must match the supported list
    /// and must not match the unsupported list.
    /// </para></li></ul><para>
    /// Instance type entries support wildcard patterns using <c>*</c> (for example, <c>t3.*</c>
    /// matches all t3 sizes).
    /// </para><para>
    /// To remove an existing instance type specification, omit the <c>InstanceTypeSpecification</c>
    /// parameter or set it to <c>null</c>.
    /// </para><para>
    /// To set the instance type specification, you must be the AMI owner. You cannot set
    /// an instance type specification on an AMI that is listed in Amazon Web Services Marketplace,
    /// and you cannot list an AMI in Amazon Web Services Marketplace if it has an instance
    /// type specification set.
    /// </para>
    /// </summary>
    [Cmdlet("Set", "EC2ImageInstanceTypeSpecification", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.Boolean")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) ReplaceImageInstanceTypeSpecification API operation.", Operation = new[] {"ReplaceImageInstanceTypeSpecification"}, SelectReturnType = typeof(Amazon.EC2.Model.ReplaceImageInstanceTypeSpecificationResponse))]
    [AWSCmdletOutput("System.Boolean or Amazon.EC2.Model.ReplaceImageInstanceTypeSpecificationResponse",
        "This cmdlet returns a collection of System.Boolean objects.",
        "The service call response (type Amazon.EC2.Model.ReplaceImageInstanceTypeSpecificationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class SetEC2ImageInstanceTypeSpecificationCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DryRun
        /// <summary>
        /// <para>
        /// <para>Checks whether you have the required permissions for the action, without actually
        /// making the request, and provides an error response. If you have the required permissions,
        /// the error response is <c>DryRunOperation</c>. Otherwise, it is <c>UnauthorizedOperation</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DryRun { get; set; }
        #endregion
        
        #region Parameter ImageId
        /// <summary>
        /// <para>
        /// <para>The ID of the AMI.</para>
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
        public System.String ImageId { get; set; }
        #endregion
        
        #region Parameter InstanceTypeSpecification_SupportedInstanceType
        /// <summary>
        /// <para>
        /// <para>The instance types that the AMI supports. You can specify instance type names or use
        /// wildcard patterns (for example, <c>t3.*</c>).</para><para>Constraints: Maximum 100 entries. Each entry must be 1-24 characters and match the
        /// pattern <c>^[A-Za-z0-9_.*-]+$</c>. Consecutive wildcard characters (<c>**</c>) are
        /// not allowed. Entries must be unique within each list and across both lists; duplicate
        /// entries cause the request to fail.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceTypeSpecification_SupportedInstanceTypes")]
        public System.String[] InstanceTypeSpecification_SupportedInstanceType { get; set; }
        #endregion
        
        #region Parameter InstanceTypeSpecification_UnsupportedInstanceType
        /// <summary>
        /// <para>
        /// <para>The instance types that the AMI does not support. You can specify instance type names
        /// or use wildcard patterns (for example, <c>t3.*</c>).</para><para>Constraints: Maximum 100 entries. Each entry must be 1-24 characters and match the
        /// pattern <c>^[A-Za-z0-9_.*-]+$</c>. Consecutive wildcard characters (<c>**</c>) are
        /// not allowed. Entries must be unique within each list and across both lists; duplicate
        /// entries cause the request to fail.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceTypeSpecification_UnsupportedInstanceTypes")]
        public System.String[] InstanceTypeSpecification_UnsupportedInstanceType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ReturnValue'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.ReplaceImageInstanceTypeSpecificationResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.ReplaceImageInstanceTypeSpecificationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ReturnValue";
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Set-EC2ImageInstanceTypeSpecification (ReplaceImageInstanceTypeSpecification)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.ReplaceImageInstanceTypeSpecificationResponse, SetEC2ImageInstanceTypeSpecificationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DryRun = this.DryRun;
            context.ImageId = this.ImageId;
            #if MODULAR
            if (this.ImageId == null && ParameterWasBound(nameof(this.ImageId)))
            {
                WriteWarning("You are passing $null as a value for parameter ImageId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.InstanceTypeSpecification_SupportedInstanceType != null)
            {
                context.InstanceTypeSpecification_SupportedInstanceType = new List<System.String>(this.InstanceTypeSpecification_SupportedInstanceType);
            }
            if (this.InstanceTypeSpecification_UnsupportedInstanceType != null)
            {
                context.InstanceTypeSpecification_UnsupportedInstanceType = new List<System.String>(this.InstanceTypeSpecification_UnsupportedInstanceType);
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
            var request = new Amazon.EC2.Model.ReplaceImageInstanceTypeSpecificationRequest();
            
            if (cmdletContext.DryRun != null)
            {
                request.DryRun = cmdletContext.DryRun.Value;
            }
            if (cmdletContext.ImageId != null)
            {
                request.ImageId = cmdletContext.ImageId;
            }
            
             // populate InstanceTypeSpecification
            var requestInstanceTypeSpecificationIsNull = true;
            request.InstanceTypeSpecification = new Amazon.EC2.Model.InstanceTypeSpecificationRequest();
            List<System.String> requestInstanceTypeSpecification_instanceTypeSpecification_SupportedInstanceType = null;
            if (cmdletContext.InstanceTypeSpecification_SupportedInstanceType != null)
            {
                requestInstanceTypeSpecification_instanceTypeSpecification_SupportedInstanceType = cmdletContext.InstanceTypeSpecification_SupportedInstanceType;
            }
            if (requestInstanceTypeSpecification_instanceTypeSpecification_SupportedInstanceType != null)
            {
                request.InstanceTypeSpecification.SupportedInstanceTypes = requestInstanceTypeSpecification_instanceTypeSpecification_SupportedInstanceType;
                requestInstanceTypeSpecificationIsNull = false;
            }
            List<System.String> requestInstanceTypeSpecification_instanceTypeSpecification_UnsupportedInstanceType = null;
            if (cmdletContext.InstanceTypeSpecification_UnsupportedInstanceType != null)
            {
                requestInstanceTypeSpecification_instanceTypeSpecification_UnsupportedInstanceType = cmdletContext.InstanceTypeSpecification_UnsupportedInstanceType;
            }
            if (requestInstanceTypeSpecification_instanceTypeSpecification_UnsupportedInstanceType != null)
            {
                request.InstanceTypeSpecification.UnsupportedInstanceTypes = requestInstanceTypeSpecification_instanceTypeSpecification_UnsupportedInstanceType;
                requestInstanceTypeSpecificationIsNull = false;
            }
             // determine if request.InstanceTypeSpecification should be set to null
            if (requestInstanceTypeSpecificationIsNull)
            {
                request.InstanceTypeSpecification = null;
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
        
        private Amazon.EC2.Model.ReplaceImageInstanceTypeSpecificationResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.ReplaceImageInstanceTypeSpecificationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "ReplaceImageInstanceTypeSpecification");
            try
            {
                return client.ReplaceImageInstanceTypeSpecificationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Boolean? DryRun { get; set; }
            public System.String ImageId { get; set; }
            public List<System.String> InstanceTypeSpecification_SupportedInstanceType { get; set; }
            public List<System.String> InstanceTypeSpecification_UnsupportedInstanceType { get; set; }
            public System.Func<Amazon.EC2.Model.ReplaceImageInstanceTypeSpecificationResponse, SetEC2ImageInstanceTypeSpecificationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ReturnValue;
        }
        
    }
}
