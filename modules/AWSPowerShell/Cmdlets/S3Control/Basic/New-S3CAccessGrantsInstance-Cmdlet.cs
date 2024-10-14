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
    /// Creates an S3 Access Grants instance, which serves as a logical grouping for access
    /// grants. You can create one S3 Access Grants instance per Region per account. 
    /// 
    ///  <dl><dt>Permissions</dt><dd><para>
    /// You must have the <c>s3:CreateAccessGrantsInstance</c> permission to use this operation.
    /// 
    /// </para></dd><dt>Additional Permissions</dt><dd><para>
    /// To associate an IAM Identity Center instance with your S3 Access Grants instance,
    /// you must also have the <c>sso:DescribeInstance</c>, <c>sso:CreateApplication</c>,
    /// <c>sso:PutApplicationGrant</c>, and <c>sso:PutApplicationAuthenticationMethod</c>
    /// permissions. 
    /// </para></dd></dl>
    /// </summary>
    [Cmdlet("New", "S3CAccessGrantsInstance", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.S3Control.Model.CreateAccessGrantsInstanceResponse")]
    [AWSCmdlet("Calls the Amazon S3 Control CreateAccessGrantsInstance API operation.", Operation = new[] {"CreateAccessGrantsInstance"}, SelectReturnType = typeof(Amazon.S3Control.Model.CreateAccessGrantsInstanceResponse))]
    [AWSCmdletOutput("Amazon.S3Control.Model.CreateAccessGrantsInstanceResponse",
        "This cmdlet returns an Amazon.S3Control.Model.CreateAccessGrantsInstanceResponse object containing multiple properties."
    )]
    public partial class NewS3CAccessGrantsInstanceCmdlet : AmazonS3ControlClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AccountId
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services account ID of the S3 Access Grants instance.</para>
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
        public System.String AccountId { get; set; }
        #endregion
        
        #region Parameter IdentityCenterArn
        /// <summary>
        /// <para>
        /// <para>If you would like to associate your S3 Access Grants instance with an Amazon Web Services
        /// IAM Identity Center instance, use this field to pass the Amazon Resource Name (ARN)
        /// of the Amazon Web Services IAM Identity Center instance that you are associating with
        /// your S3 Access Grants instance. An IAM Identity Center instance is your corporate
        /// identity directory that you added to the IAM Identity Center. You can use the <a href="https://docs.aws.amazon.com/singlesignon/latest/APIReference/API_ListInstances.html">ListInstances</a>
        /// API operation to retrieve a list of your Identity Center instances and their ARNs.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IdentityCenterArn { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services resource tags that you are adding to the S3 Access Grants
        /// instance. Each tag is a label consisting of a user-defined key and value. Tags can
        /// help you manage, identify, organize, search for, and filter resources. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.S3Control.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.S3Control.Model.CreateAccessGrantsInstanceResponse).
        /// Specifying the name of a property of type Amazon.S3Control.Model.CreateAccessGrantsInstanceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the AccountId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^AccountId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^AccountId' instead. This parameter will be removed in a future version.")]
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
            this._AWSSignerType = "s3v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AccountId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-S3CAccessGrantsInstance (CreateAccessGrantsInstance)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.S3Control.Model.CreateAccessGrantsInstanceResponse, NewS3CAccessGrantsInstanceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.AccountId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AccountId = this.AccountId;
            #if MODULAR
            if (this.AccountId == null && ParameterWasBound(nameof(this.AccountId)))
            {
                WriteWarning("You are passing $null as a value for parameter AccountId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IdentityCenterArn = this.IdentityCenterArn;
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
            var request = new Amazon.S3Control.Model.CreateAccessGrantsInstanceRequest();
            
            if (cmdletContext.AccountId != null)
            {
                request.AccountId = cmdletContext.AccountId;
            }
            if (cmdletContext.IdentityCenterArn != null)
            {
                request.IdentityCenterArn = cmdletContext.IdentityCenterArn;
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
        
        private Amazon.S3Control.Model.CreateAccessGrantsInstanceResponse CallAWSServiceOperation(IAmazonS3Control client, Amazon.S3Control.Model.CreateAccessGrantsInstanceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon S3 Control", "CreateAccessGrantsInstance");
            try
            {
                #if DESKTOP
                return client.CreateAccessGrantsInstance(request);
                #elif CORECLR
                return client.CreateAccessGrantsInstanceAsync(request).GetAwaiter().GetResult();
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
            public System.String IdentityCenterArn { get; set; }
            public List<Amazon.S3Control.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.S3Control.Model.CreateAccessGrantsInstanceResponse, NewS3CAccessGrantsInstanceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
