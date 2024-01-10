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
using Amazon.S3Control;
using Amazon.S3Control.Model;

namespace Amazon.PowerShell.Cmdlets.S3C
{
    /// <summary>
    /// Updates the IAM role of a registered location in your S3 Access Grants instance.
    /// 
    ///  <dl><dt>Permissions</dt><dd><para>
    /// You must have the <c>s3:UpdateAccessGrantsLocation</c> permission to use this operation.
    /// 
    /// </para></dd><dt>Additional Permissions</dt><dd><para>
    /// You must also have the following permission: <c>iam:PassRole</c></para></dd></dl>
    /// </summary>
    [Cmdlet("Update", "S3CAccessGrantsLocation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.S3Control.Model.UpdateAccessGrantsLocationResponse")]
    [AWSCmdlet("Calls the Amazon S3 Control UpdateAccessGrantsLocation API operation.", Operation = new[] {"UpdateAccessGrantsLocation"}, SelectReturnType = typeof(Amazon.S3Control.Model.UpdateAccessGrantsLocationResponse))]
    [AWSCmdletOutput("Amazon.S3Control.Model.UpdateAccessGrantsLocationResponse",
        "This cmdlet returns an Amazon.S3Control.Model.UpdateAccessGrantsLocationResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateS3CAccessGrantsLocationCmdlet : AmazonS3ControlClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AccessGrantsLocationId
        /// <summary>
        /// <para>
        /// <para>The ID of the registered location that you are updating. S3 Access Grants assigns
        /// this ID when you register the location. S3 Access Grants assigns the ID <c>default</c>
        /// to the default location <c>s3://</c> and assigns an auto-generated ID to other locations
        /// that you register. </para><para>The ID of the registered location to which you are granting access. S3 Access Grants
        /// assigned this ID when you registered the location. S3 Access Grants assigns the ID
        /// <c>default</c> to the default location <c>s3://</c> and assigns an auto-generated
        /// ID to other locations that you register. </para><para>If you are passing the <c>default</c> location, you cannot create an access grant
        /// for the entire default location. You must also specify a bucket or a bucket and prefix
        /// in the <c>Subprefix</c> field. </para>
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
        public System.String AccessGrantsLocationId { get; set; }
        #endregion
        
        #region Parameter AccountId
        /// <summary>
        /// <para>
        /// <para>The ID of the Amazon Web Services account that is making this request.</para>
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String IAMRoleArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.S3Control.Model.UpdateAccessGrantsLocationResponse).
        /// Specifying the name of a property of type Amazon.S3Control.Model.UpdateAccessGrantsLocationResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-S3CAccessGrantsLocation (UpdateAccessGrantsLocation)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.S3Control.Model.UpdateAccessGrantsLocationResponse, UpdateS3CAccessGrantsLocationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AccessGrantsLocationId = this.AccessGrantsLocationId;
            #if MODULAR
            if (this.AccessGrantsLocationId == null && ParameterWasBound(nameof(this.AccessGrantsLocationId)))
            {
                WriteWarning("You are passing $null as a value for parameter AccessGrantsLocationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            var request = new Amazon.S3Control.Model.UpdateAccessGrantsLocationRequest();
            
            if (cmdletContext.AccessGrantsLocationId != null)
            {
                request.AccessGrantsLocationId = cmdletContext.AccessGrantsLocationId;
            }
            if (cmdletContext.AccountId != null)
            {
                request.AccountId = cmdletContext.AccountId;
            }
            if (cmdletContext.IAMRoleArn != null)
            {
                request.IAMRoleArn = cmdletContext.IAMRoleArn;
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
        
        private Amazon.S3Control.Model.UpdateAccessGrantsLocationResponse CallAWSServiceOperation(IAmazonS3Control client, Amazon.S3Control.Model.UpdateAccessGrantsLocationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon S3 Control", "UpdateAccessGrantsLocation");
            try
            {
                #if DESKTOP
                return client.UpdateAccessGrantsLocation(request);
                #elif CORECLR
                return client.UpdateAccessGrantsLocationAsync(request).GetAwaiter().GetResult();
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
            public System.String AccessGrantsLocationId { get; set; }
            public System.String AccountId { get; set; }
            public System.String IAMRoleArn { get; set; }
            public System.Func<Amazon.S3Control.Model.UpdateAccessGrantsLocationResponse, UpdateS3CAccessGrantsLocationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
