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
using Amazon.S3Control;
using Amazon.S3Control.Model;

namespace Amazon.PowerShell.Cmdlets.S3C
{
    /// <summary>
    /// The S3 data location that you would like to register in your S3 Access Grants instance.
    /// Your S3 data must be in the same Region as your S3 Access Grants instance. The location
    /// can be one of the following: 
    /// 
    ///  <ul><li><para>
    /// The default S3 location <c>s3://</c></para></li><li><para>
    /// A bucket - <c>S3://&lt;bucket-name&gt;</c></para></li><li><para>
    /// A bucket and prefix - <c>S3://&lt;bucket-name&gt;/&lt;prefix&gt;</c></para></li></ul><para>
    /// When you register a location, you must include the IAM role that has permission to
    /// manage the S3 location that you are registering. Give S3 Access Grants permission
    /// to assume this role <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/access-grants-location.html">using
    /// a policy</a>. S3 Access Grants assumes this role to manage access to the location
    /// and to vend temporary credentials to grantees or client applications. 
    /// </para><dl><dt>Permissions</dt><dd><para>
    /// You must have the <c>s3:CreateAccessGrantsLocation</c> permission to use this operation.
    /// 
    /// </para></dd><dt>Additional Permissions</dt><dd><para>
    /// You must also have the following permission for the specified IAM role: <c>iam:PassRole</c></para></dd></dl>
    /// </summary>
    [Cmdlet("New", "S3CAccessGrantsLocation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.S3Control.Model.CreateAccessGrantsLocationResponse")]
    [AWSCmdlet("Calls the Amazon S3 Control CreateAccessGrantsLocation API operation.", Operation = new[] {"CreateAccessGrantsLocation"}, SelectReturnType = typeof(Amazon.S3Control.Model.CreateAccessGrantsLocationResponse))]
    [AWSCmdletOutput("Amazon.S3Control.Model.CreateAccessGrantsLocationResponse",
        "This cmdlet returns an Amazon.S3Control.Model.CreateAccessGrantsLocationResponse object containing multiple properties."
    )]
    public partial class NewS3CAccessGrantsLocationCmdlet : AmazonS3ControlClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AccountId
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services account ID of the S3 Access Grants instance.</para>
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
        public System.String AccountId { get; set; }
        #endregion
        
        #region Parameter IAMRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM role for the registered location. S3 Access
        /// Grants assumes this role to manage access to the registered location. </para>
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
        public System.String IAMRoleArn { get; set; }
        #endregion
        
        #region Parameter LocationScope
        /// <summary>
        /// <para>
        /// <para>The S3 path to the location that you are registering. The location scope can be the
        /// default S3 location <c>s3://</c>, the S3 path to a bucket <c>s3://&lt;bucket&gt;</c>,
        /// or the S3 path to a bucket and prefix <c>s3://&lt;bucket&gt;/&lt;prefix&gt;</c>. A
        /// prefix in S3 is a string of characters at the beginning of an object key name used
        /// to organize the objects that you store in your S3 buckets. For example, object key
        /// names that start with the <c>engineering/</c> prefix or object key names that start
        /// with the <c>marketing/campaigns/</c> prefix.</para>
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
        public System.String LocationScope { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services resource tags that you are adding to the S3 Access Grants
        /// location. Each tag is a label consisting of a user-defined key and value. Tags can
        /// help you manage, identify, organize, search for, and filter resources.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.S3Control.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.S3Control.Model.CreateAccessGrantsLocationResponse).
        /// Specifying the name of a property of type Amazon.S3Control.Model.CreateAccessGrantsLocationResponse will result in that property being returned.
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
            this._AWSSignerType = "s3v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.IAMRoleArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-S3CAccessGrantsLocation (CreateAccessGrantsLocation)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.S3Control.Model.CreateAccessGrantsLocationResponse, NewS3CAccessGrantsLocationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AccountId = this.AccountId;
            #if MODULAR
            if (this.AccountId == null && ParameterWasBound(nameof(this.AccountId)))
            {
                WriteWarning("You are passing $null as a value for parameter AccountId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IAMRoleArn = this.IAMRoleArn;
            #if MODULAR
            if (this.IAMRoleArn == null && ParameterWasBound(nameof(this.IAMRoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter IAMRoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.LocationScope = this.LocationScope;
            #if MODULAR
            if (this.LocationScope == null && ParameterWasBound(nameof(this.LocationScope)))
            {
                WriteWarning("You are passing $null as a value for parameter LocationScope which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.S3Control.Model.Tag>(this.Tag);
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
            var request = new Amazon.S3Control.Model.CreateAccessGrantsLocationRequest();
            
            if (cmdletContext.AccountId != null)
            {
                request.AccountId = cmdletContext.AccountId;
            }
            if (cmdletContext.IAMRoleArn != null)
            {
                request.IAMRoleArn = cmdletContext.IAMRoleArn;
            }
            if (cmdletContext.LocationScope != null)
            {
                request.LocationScope = cmdletContext.LocationScope;
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
        
        private Amazon.S3Control.Model.CreateAccessGrantsLocationResponse CallAWSServiceOperation(IAmazonS3Control client, Amazon.S3Control.Model.CreateAccessGrantsLocationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon S3 Control", "CreateAccessGrantsLocation");
            try
            {
                #if DESKTOP
                return client.CreateAccessGrantsLocation(request);
                #elif CORECLR
                return client.CreateAccessGrantsLocationAsync(request).GetAwaiter().GetResult();
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
            public System.String AccountId { get; set; }
            public System.String IAMRoleArn { get; set; }
            public System.String LocationScope { get; set; }
            public List<Amazon.S3Control.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.S3Control.Model.CreateAccessGrantsLocationResponse, NewS3CAccessGrantsLocationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
