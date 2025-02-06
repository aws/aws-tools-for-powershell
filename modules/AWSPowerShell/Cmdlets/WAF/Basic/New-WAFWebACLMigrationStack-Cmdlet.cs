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
using Amazon.WAF;
using Amazon.WAF.Model;

namespace Amazon.PowerShell.Cmdlets.WAF
{
    /// <summary>
    /// Creates an AWS CloudFormation WAFV2 template for the specified web ACL in the specified
    /// Amazon S3 bucket. Then, in CloudFormation, you create a stack from the template, to
    /// create the web ACL and its resources in AWS WAFV2. Use this to migrate your AWS WAF
    /// Classic web ACL to the latest version of AWS WAF.
    /// 
    ///  
    /// <para>
    /// This is part of a larger migration procedure for web ACLs from AWS WAF Classic to
    /// the latest version of AWS WAF. For the full procedure, including caveats and manual
    /// steps to complete the migration and switch over to the new web ACL, see <a href="https://docs.aws.amazon.com/waf/latest/developerguide/waf-migrating-from-classic.html">Migrating
    /// your AWS WAF Classic resources to AWS WAF</a> in the <a href="https://docs.aws.amazon.com/waf/latest/developerguide/waf-chapter.html">AWS
    /// WAF Developer Guide</a>. 
    /// </para>
    /// </summary>
    [Cmdlet("New", "WAFWebACLMigrationStack", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.WAF.Model.CreateWebACLMigrationStackResponse")]
    [AWSCmdlet("Calls the AWS WAF CreateWebACLMigrationStack API operation.", Operation = new[] {"CreateWebACLMigrationStack"}, SelectReturnType = typeof(Amazon.WAF.Model.CreateWebACLMigrationStackResponse))]
    [AWSCmdletOutput("Amazon.WAF.Model.CreateWebACLMigrationStackResponse",
        "This cmdlet returns an Amazon.WAF.Model.CreateWebACLMigrationStackResponse object containing multiple properties."
    )]
    public partial class NewWAFWebACLMigrationStackCmdlet : AmazonWAFClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter IgnoreUnsupportedType
        /// <summary>
        /// <para>
        /// <para>Indicates whether to exclude entities that can't be migrated or to stop the migration.
        /// Set this to true to ignore unsupported entities in the web ACL during the migration.
        /// Otherwise, if AWS WAF encounters unsupported entities, it stops the process and throws
        /// an exception. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Boolean? IgnoreUnsupportedType { get; set; }
        #endregion
        
        #region Parameter S3BucketName
        /// <summary>
        /// <para>
        /// <para>The name of the Amazon S3 bucket to store the CloudFormation template in. The S3 bucket
        /// must be configured as follows for the migration: </para><ul><li><para>The bucket name must start with <c>aws-waf-migration-</c>. For example, <c>aws-waf-migration-my-web-acl</c>.</para></li><li><para>The bucket must be in the Region where you are deploying the template. For example,
        /// for a web ACL in us-west-2, you must use an Amazon S3 bucket in us-west-2 and you
        /// must deploy the template stack to us-west-2. </para></li><li><para>The bucket policies must permit the migration process to write data. For listings
        /// of the bucket policies, see the Examples section. </para></li></ul>
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
        public System.String S3BucketName { get; set; }
        #endregion
        
        #region Parameter WebACLId
        /// <summary>
        /// <para>
        /// <para>The UUID of the WAF Classic web ACL that you want to migrate to WAF v2.</para>
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
        public System.String WebACLId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.WAF.Model.CreateWebACLMigrationStackResponse).
        /// Specifying the name of a property of type Amazon.WAF.Model.CreateWebACLMigrationStackResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.WebACLId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-WAFWebACLMigrationStack (CreateWebACLMigrationStack)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.WAF.Model.CreateWebACLMigrationStackResponse, NewWAFWebACLMigrationStackCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.IgnoreUnsupportedType = this.IgnoreUnsupportedType;
            #if MODULAR
            if (this.IgnoreUnsupportedType == null && ParameterWasBound(nameof(this.IgnoreUnsupportedType)))
            {
                WriteWarning("You are passing $null as a value for parameter IgnoreUnsupportedType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.S3BucketName = this.S3BucketName;
            #if MODULAR
            if (this.S3BucketName == null && ParameterWasBound(nameof(this.S3BucketName)))
            {
                WriteWarning("You are passing $null as a value for parameter S3BucketName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.WebACLId = this.WebACLId;
            #if MODULAR
            if (this.WebACLId == null && ParameterWasBound(nameof(this.WebACLId)))
            {
                WriteWarning("You are passing $null as a value for parameter WebACLId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.WAF.Model.CreateWebACLMigrationStackRequest();
            
            if (cmdletContext.IgnoreUnsupportedType != null)
            {
                request.IgnoreUnsupportedType = cmdletContext.IgnoreUnsupportedType.Value;
            }
            if (cmdletContext.S3BucketName != null)
            {
                request.S3BucketName = cmdletContext.S3BucketName;
            }
            if (cmdletContext.WebACLId != null)
            {
                request.WebACLId = cmdletContext.WebACLId;
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
        
        private Amazon.WAF.Model.CreateWebACLMigrationStackResponse CallAWSServiceOperation(IAmazonWAF client, Amazon.WAF.Model.CreateWebACLMigrationStackRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS WAF", "CreateWebACLMigrationStack");
            try
            {
                #if DESKTOP
                return client.CreateWebACLMigrationStack(request);
                #elif CORECLR
                return client.CreateWebACLMigrationStackAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? IgnoreUnsupportedType { get; set; }
            public System.String S3BucketName { get; set; }
            public System.String WebACLId { get; set; }
            public System.Func<Amazon.WAF.Model.CreateWebACLMigrationStackResponse, NewWAFWebACLMigrationStackCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
