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
using Amazon.ResilienceHub;
using Amazon.ResilienceHub.Model;

namespace Amazon.PowerShell.Cmdlets.RESH
{
    /// <summary>
    /// Creates an Resilience Hub application. An Resilience Hub application is a collection
    /// of Amazon Web Services resources structured to prevent and recover Amazon Web Services
    /// application disruptions. To describe a Resilience Hub application, you provide an
    /// application name, resources from one or more CloudFormation stacks, Resource Groups,
    /// Terraform state files, AppRegistry applications, and an appropriate resiliency policy.
    /// In addition, you can also add resources that are located on Amazon Elastic Kubernetes
    /// Service (Amazon EKS) clusters as optional resources. For more information about the
    /// number of resources supported per application, see <a href="https://docs.aws.amazon.com/general/latest/gr/resiliencehub.html#limits_resiliencehub">Service
    /// quotas</a>.
    /// 
    ///  
    /// <para>
    /// After you create an Resilience Hub application, you publish it so that you can run
    /// a resiliency assessment on it. You can then use recommendations from the assessment
    /// to improve resiliency by running another assessment, comparing results, and then iterating
    /// the process until you achieve your goals for recovery time objective (RTO) and recovery
    /// point objective (RPO).
    /// </para>
    /// </summary>
    [Cmdlet("New", "RESHApp", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ResilienceHub.Model.App")]
    [AWSCmdlet("Calls the AWS Resilience Hub CreateApp API operation.", Operation = new[] {"CreateApp"}, SelectReturnType = typeof(Amazon.ResilienceHub.Model.CreateAppResponse))]
    [AWSCmdletOutput("Amazon.ResilienceHub.Model.App or Amazon.ResilienceHub.Model.CreateAppResponse",
        "This cmdlet returns an Amazon.ResilienceHub.Model.App object.",
        "The service call response (type Amazon.ResilienceHub.Model.CreateAppResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewRESHAppCmdlet : AmazonResilienceHubClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AssessmentSchedule
        /// <summary>
        /// <para>
        /// <para> Assessment execution schedule with 'Daily' or 'Disabled' values. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ResilienceHub.AppAssessmentScheduleType")]
        public Amazon.ResilienceHub.AppAssessmentScheduleType AssessmentSchedule { get; set; }
        #endregion
        
        #region Parameter AwsApplicationArn
        /// <summary>
        /// <para>
        /// <para>Amazon Resource Name (ARN) of Resource Groups group that is integrated with an AppRegistry
        /// application. For more information about ARNs, see <a href="https://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html">
        /// Amazon Resource Names (ARNs)</a> in the <i>Amazon Web Services General Reference</i>
        /// guide.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AwsApplicationArn { get; set; }
        #endregion
        
        #region Parameter PermissionModel_CrossAccountRoleArn
        /// <summary>
        /// <para>
        /// <para>Defines a list of role Amazon Resource Names (ARNs) to be used in other accounts.
        /// These ARNs are used for querying purposes while importing resources and assessing
        /// your application.</para><note><ul><li><para>These ARNs are required only when your resources are in other accounts and you have
        /// different role name in these accounts. Else, the invoker role name will be used in
        /// the other accounts.</para></li><li><para>These roles must have a trust policy with <c>iam:AssumeRole</c> permission to the
        /// invoker role in the primary account.</para></li></ul></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PermissionModel_CrossAccountRoleArns")]
        public System.String[] PermissionModel_CrossAccountRoleArn { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The optional description for an app.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter EventSubscription
        /// <summary>
        /// <para>
        /// <para>The list of events you would like to subscribe and get notification for. Currently,
        /// Resilience Hub supports only <b>Drift detected</b> and <b>Scheduled assessment failure</b>
        /// events notification.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EventSubscriptions")]
        public Amazon.ResilienceHub.Model.EventSubscription[] EventSubscription { get; set; }
        #endregion
        
        #region Parameter PermissionModel_InvokerRoleName
        /// <summary>
        /// <para>
        /// <para>Existing Amazon Web Services IAM role name in the primary Amazon Web Services account
        /// that will be assumed by Resilience Hub Service Principle to obtain a read-only access
        /// to your application resources while running an assessment. </para><para>If your IAM role includes a path, you must include the path in the <c>invokerRoleName</c>
        /// parameter. For example, if your IAM role's ARN is <c>arn:aws:iam:123456789012:role/my-path/role-name</c>,
        /// you should pass <c>my-path/role-name</c>. </para><note><ul><li><para>You must have <c>iam:passRole</c> permission for this role while creating or updating
        /// the application.</para></li><li><para>Currently, <c>invokerRoleName</c> accepts only <c>[A-Za-z0-9_+=,.@-]</c> characters.</para></li></ul></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PermissionModel_InvokerRoleName { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>Name of the application.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter PolicyArn
        /// <summary>
        /// <para>
        /// <para>Amazon Resource Name (ARN) of the resiliency policy. The format for this ARN is: arn:<c>partition</c>:resiliencehub:<c>region</c>:<c>account</c>:resiliency-policy/<c>policy-id</c>.
        /// For more information about ARNs, see <a href="https://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html">
        /// Amazon Resource Names (ARNs)</a> in the <i>Amazon Web Services General Reference</i>
        /// guide.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PolicyArn { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Tags assigned to the resource. A tag is a label that you assign to an Amazon Web Services
        /// resource. Each tag consists of a key/value pair.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter PermissionModel_Type
        /// <summary>
        /// <para>
        /// <para>Defines how Resilience Hub scans your resources. It can scan for the resources by
        /// using a pre-existing role in your Amazon Web Services account, or by using the credentials
        /// of the current IAM user.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ResilienceHub.PermissionModelType")]
        public Amazon.ResilienceHub.PermissionModelType PermissionModel_Type { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Used for an idempotency token. A client token is a unique, case-sensitive string of
        /// up to 64 ASCII characters. You should not reuse the same client token for other API
        /// requests.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'App'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ResilienceHub.Model.CreateAppResponse).
        /// Specifying the name of a property of type Amazon.ResilienceHub.Model.CreateAppResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "App";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-RESHApp (CreateApp)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ResilienceHub.Model.CreateAppResponse, NewRESHAppCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AssessmentSchedule = this.AssessmentSchedule;
            context.AwsApplicationArn = this.AwsApplicationArn;
            context.ClientToken = this.ClientToken;
            context.Description = this.Description;
            if (this.EventSubscription != null)
            {
                context.EventSubscription = new List<Amazon.ResilienceHub.Model.EventSubscription>(this.EventSubscription);
            }
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.PermissionModel_CrossAccountRoleArn != null)
            {
                context.PermissionModel_CrossAccountRoleArn = new List<System.String>(this.PermissionModel_CrossAccountRoleArn);
            }
            context.PermissionModel_InvokerRoleName = this.PermissionModel_InvokerRoleName;
            context.PermissionModel_Type = this.PermissionModel_Type;
            context.PolicyArn = this.PolicyArn;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
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
            var request = new Amazon.ResilienceHub.Model.CreateAppRequest();
            
            if (cmdletContext.AssessmentSchedule != null)
            {
                request.AssessmentSchedule = cmdletContext.AssessmentSchedule;
            }
            if (cmdletContext.AwsApplicationArn != null)
            {
                request.AwsApplicationArn = cmdletContext.AwsApplicationArn;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.EventSubscription != null)
            {
                request.EventSubscriptions = cmdletContext.EventSubscription;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate PermissionModel
            var requestPermissionModelIsNull = true;
            request.PermissionModel = new Amazon.ResilienceHub.Model.PermissionModel();
            List<System.String> requestPermissionModel_permissionModel_CrossAccountRoleArn = null;
            if (cmdletContext.PermissionModel_CrossAccountRoleArn != null)
            {
                requestPermissionModel_permissionModel_CrossAccountRoleArn = cmdletContext.PermissionModel_CrossAccountRoleArn;
            }
            if (requestPermissionModel_permissionModel_CrossAccountRoleArn != null)
            {
                request.PermissionModel.CrossAccountRoleArns = requestPermissionModel_permissionModel_CrossAccountRoleArn;
                requestPermissionModelIsNull = false;
            }
            System.String requestPermissionModel_permissionModel_InvokerRoleName = null;
            if (cmdletContext.PermissionModel_InvokerRoleName != null)
            {
                requestPermissionModel_permissionModel_InvokerRoleName = cmdletContext.PermissionModel_InvokerRoleName;
            }
            if (requestPermissionModel_permissionModel_InvokerRoleName != null)
            {
                request.PermissionModel.InvokerRoleName = requestPermissionModel_permissionModel_InvokerRoleName;
                requestPermissionModelIsNull = false;
            }
            Amazon.ResilienceHub.PermissionModelType requestPermissionModel_permissionModel_Type = null;
            if (cmdletContext.PermissionModel_Type != null)
            {
                requestPermissionModel_permissionModel_Type = cmdletContext.PermissionModel_Type;
            }
            if (requestPermissionModel_permissionModel_Type != null)
            {
                request.PermissionModel.Type = requestPermissionModel_permissionModel_Type;
                requestPermissionModelIsNull = false;
            }
             // determine if request.PermissionModel should be set to null
            if (requestPermissionModelIsNull)
            {
                request.PermissionModel = null;
            }
            if (cmdletContext.PolicyArn != null)
            {
                request.PolicyArn = cmdletContext.PolicyArn;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.ResilienceHub.Model.CreateAppResponse CallAWSServiceOperation(IAmazonResilienceHub client, Amazon.ResilienceHub.Model.CreateAppRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Resilience Hub", "CreateApp");
            try
            {
                #if DESKTOP
                return client.CreateApp(request);
                #elif CORECLR
                return client.CreateAppAsync(request).GetAwaiter().GetResult();
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
            public Amazon.ResilienceHub.AppAssessmentScheduleType AssessmentSchedule { get; set; }
            public System.String AwsApplicationArn { get; set; }
            public System.String ClientToken { get; set; }
            public System.String Description { get; set; }
            public List<Amazon.ResilienceHub.Model.EventSubscription> EventSubscription { get; set; }
            public System.String Name { get; set; }
            public List<System.String> PermissionModel_CrossAccountRoleArn { get; set; }
            public System.String PermissionModel_InvokerRoleName { get; set; }
            public Amazon.ResilienceHub.PermissionModelType PermissionModel_Type { get; set; }
            public System.String PolicyArn { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.ResilienceHub.Model.CreateAppResponse, NewRESHAppCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.App;
        }
        
    }
}
