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

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Creates a launch template.
    /// 
    ///  
    /// <para>
    /// A launch template contains the parameters to launch an instance. When you launch an
    /// instance using <a>RunInstances</a>, you can specify a launch template instead of providing
    /// the launch parameters in the request. For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/ec2-launch-templates.html">Launch
    /// an instance from a launch template</a> in the <i>Amazon EC2 User Guide</i>.
    /// </para><para>
    /// To clone an existing launch template as the basis for a new launch template, use the
    /// Amazon EC2 console. The API, SDKs, and CLI do not support cloning a template. For
    /// more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/ec2-launch-templates.html#create-launch-template-from-existing-launch-template">Create
    /// a launch template from an existing launch template</a> in the <i>Amazon EC2 User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "EC2LaunchTemplate", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.LaunchTemplate")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) CreateLaunchTemplate API operation.", Operation = new[] {"CreateLaunchTemplate"}, SelectReturnType = typeof(Amazon.EC2.Model.CreateLaunchTemplateResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.LaunchTemplate or Amazon.EC2.Model.CreateLaunchTemplateResponse",
        "This cmdlet returns an Amazon.EC2.Model.LaunchTemplate object.",
        "The service call response (type Amazon.EC2.Model.CreateLaunchTemplateResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewEC2LaunchTemplateCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter LaunchTemplateData
        /// <summary>
        /// <para>
        /// <para>The information for the launch template.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public Amazon.EC2.Model.RequestLaunchTemplateData LaunchTemplateData { get; set; }
        #endregion
        
        #region Parameter LaunchTemplateName
        /// <summary>
        /// <para>
        /// <para>A name for the launch template.</para>
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
        public System.String LaunchTemplateName { get; set; }
        #endregion
        
        #region Parameter Operator_Principal
        /// <summary>
        /// <para>
        /// <para>The service provider that manages the resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Operator_Principal { get; set; }
        #endregion
        
        #region Parameter TagSpecification
        /// <summary>
        /// <para>
        /// <para>The tags to apply to the launch template on creation. To tag the launch template,
        /// the resource type must be <c>launch-template</c>.</para><para>To specify the tags for the resources that are created when an instance is launched,
        /// you must use the <c>TagSpecifications</c> parameter in the <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/API_RequestLaunchTemplateData.html">launch
        /// template data</a> structure.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TagSpecifications")]
        public Amazon.EC2.Model.TagSpecification[] TagSpecification { get; set; }
        #endregion
        
        #region Parameter VersionDescription
        /// <summary>
        /// <para>
        /// <para>A description for the first version of the launch template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String VersionDescription { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Unique, case-sensitive identifier you provide to ensure the idempotency of the request.
        /// For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/Run_Instance_Idempotency.html">Ensuring
        /// idempotency</a>.</para><para>Constraint: Maximum 128 ASCII characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'LaunchTemplate'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.CreateLaunchTemplateResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.CreateLaunchTemplateResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "LaunchTemplate";
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.LaunchTemplateName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EC2LaunchTemplate (CreateLaunchTemplate)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.CreateLaunchTemplateResponse, NewEC2LaunchTemplateCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.LaunchTemplateData = this.LaunchTemplateData;
            #if MODULAR
            if (this.LaunchTemplateData == null && ParameterWasBound(nameof(this.LaunchTemplateData)))
            {
                WriteWarning("You are passing $null as a value for parameter LaunchTemplateData which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.LaunchTemplateName = this.LaunchTemplateName;
            #if MODULAR
            if (this.LaunchTemplateName == null && ParameterWasBound(nameof(this.LaunchTemplateName)))
            {
                WriteWarning("You are passing $null as a value for parameter LaunchTemplateName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Operator_Principal = this.Operator_Principal;
            if (this.TagSpecification != null)
            {
                context.TagSpecification = new List<Amazon.EC2.Model.TagSpecification>(this.TagSpecification);
            }
            context.VersionDescription = this.VersionDescription;
            
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
            var request = new Amazon.EC2.Model.CreateLaunchTemplateRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.LaunchTemplateData != null)
            {
                request.LaunchTemplateData = cmdletContext.LaunchTemplateData;
            }
            if (cmdletContext.LaunchTemplateName != null)
            {
                request.LaunchTemplateName = cmdletContext.LaunchTemplateName;
            }
            
             // populate Operator
            var requestOperatorIsNull = true;
            request.Operator = new Amazon.EC2.Model.OperatorRequest();
            System.String requestOperator_operator_Principal = null;
            if (cmdletContext.Operator_Principal != null)
            {
                requestOperator_operator_Principal = cmdletContext.Operator_Principal;
            }
            if (requestOperator_operator_Principal != null)
            {
                request.Operator.Principal = requestOperator_operator_Principal;
                requestOperatorIsNull = false;
            }
             // determine if request.Operator should be set to null
            if (requestOperatorIsNull)
            {
                request.Operator = null;
            }
            if (cmdletContext.TagSpecification != null)
            {
                request.TagSpecifications = cmdletContext.TagSpecification;
            }
            if (cmdletContext.VersionDescription != null)
            {
                request.VersionDescription = cmdletContext.VersionDescription;
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
        
        private Amazon.EC2.Model.CreateLaunchTemplateResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.CreateLaunchTemplateRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "CreateLaunchTemplate");
            try
            {
                return client.CreateLaunchTemplateAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public Amazon.EC2.Model.RequestLaunchTemplateData LaunchTemplateData { get; set; }
            public System.String LaunchTemplateName { get; set; }
            public System.String Operator_Principal { get; set; }
            public List<Amazon.EC2.Model.TagSpecification> TagSpecification { get; set; }
            public System.String VersionDescription { get; set; }
            public System.Func<Amazon.EC2.Model.CreateLaunchTemplateResponse, NewEC2LaunchTemplateCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.LaunchTemplate;
        }
        
    }
}
