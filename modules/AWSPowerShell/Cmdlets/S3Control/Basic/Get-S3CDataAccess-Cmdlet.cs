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
    /// Returns a temporary access credential from S3 Access Grants to the grantee or client
    /// application. The <a href="https://docs.aws.amazon.com/STS/latest/APIReference/API_Credentials.html">temporary
    /// credential</a> is an Amazon Web Services STS token that grants them access to the
    /// S3 data. 
    /// 
    ///  <dl><dt>Permissions</dt><dd><para>
    /// You must have the <c>s3:GetDataAccess</c> permission to use this operation. 
    /// </para></dd><dt>Additional Permissions</dt><dd><para>
    /// The IAM role that S3 Access Grants assumes must have the following permissions specified
    /// in the trust policy when registering the location: <c>sts:AssumeRole</c>, for directory
    /// users or groups <c>sts:SetContext</c>, and for IAM users or roles <c>sts:SetSourceIdentity</c>.
    /// 
    /// </para></dd></dl>
    /// </summary>
    [Cmdlet("Get", "S3CDataAccess")]
    [OutputType("Amazon.S3Control.Model.GetDataAccessResponse")]
    [AWSCmdlet("Calls the Amazon S3 Control GetDataAccess API operation.", Operation = new[] {"GetDataAccess"}, SelectReturnType = typeof(Amazon.S3Control.Model.GetDataAccessResponse))]
    [AWSCmdletOutput("Amazon.S3Control.Model.GetDataAccessResponse",
        "This cmdlet returns an Amazon.S3Control.Model.GetDataAccessResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetS3CDataAccessCmdlet : AmazonS3ControlClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
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
        
        #region Parameter DurationSecond
        /// <summary>
        /// <para>
        /// <para>The session duration, in seconds, of the temporary access credential that S3 Access
        /// Grants vends to the grantee or client application. The default value is 1 hour, but
        /// the grantee can specify a range from 900 seconds (15 minutes) up to 43200 seconds
        /// (12 hours). If the grantee requests a value higher than this maximum, the operation
        /// fails. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DurationSeconds")]
        public System.Int32? DurationSecond { get; set; }
        #endregion
        
        #region Parameter Permission
        /// <summary>
        /// <para>
        /// <para>The type of permission granted to your S3 data, which can be set to one of the following
        /// values:</para><ul><li><para><c>READ</c> – Grant read-only access to the S3 data.</para></li><li><para><c>WRITE</c> – Grant write-only access to the S3 data.</para></li><li><para><c>READWRITE</c> – Grant both read and write access to the S3 data.</para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.S3Control.Permission")]
        public Amazon.S3Control.Permission Permission { get; set; }
        #endregion
        
        #region Parameter Privilege
        /// <summary>
        /// <para>
        /// <para>The scope of the temporary access credential that S3 Access Grants vends to the grantee
        /// or client application. </para><ul><li><para><c>Default</c> – The scope of the returned temporary access token is the scope of
        /// the grant that is closest to the target scope.</para></li><li><para><c>Minimal</c> – The scope of the returned temporary access token is the same as
        /// the requested target scope as long as the requested scope is the same as or a subset
        /// of the grant scope. </para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.S3Control.Privilege")]
        public Amazon.S3Control.Privilege Privilege { get; set; }
        #endregion
        
        #region Parameter Target
        /// <summary>
        /// <para>
        /// <para>The S3 URI path of the data to which you are requesting temporary access credentials.
        /// If the requesting account has an access grant for this data, S3 Access Grants vends
        /// temporary access credentials in the response.</para>
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
        public System.String Target { get; set; }
        #endregion
        
        #region Parameter TargetType
        /// <summary>
        /// <para>
        /// <para>The type of <c>Target</c>. The only possible value is <c>Object</c>. Pass this value
        /// if the target data that you would like to access is a path to an object. Do not pass
        /// this value if the target data is a bucket or a bucket and a prefix. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.S3Control.S3PrefixType")]
        public Amazon.S3Control.S3PrefixType TargetType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.S3Control.Model.GetDataAccessResponse).
        /// Specifying the name of a property of type Amazon.S3Control.Model.GetDataAccessResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "s3v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.S3Control.Model.GetDataAccessResponse, GetS3CDataAccessCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AccountId = this.AccountId;
            #if MODULAR
            if (this.AccountId == null && ParameterWasBound(nameof(this.AccountId)))
            {
                WriteWarning("You are passing $null as a value for parameter AccountId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DurationSecond = this.DurationSecond;
            context.Permission = this.Permission;
            #if MODULAR
            if (this.Permission == null && ParameterWasBound(nameof(this.Permission)))
            {
                WriteWarning("You are passing $null as a value for parameter Permission which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Privilege = this.Privilege;
            context.Target = this.Target;
            #if MODULAR
            if (this.Target == null && ParameterWasBound(nameof(this.Target)))
            {
                WriteWarning("You are passing $null as a value for parameter Target which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TargetType = this.TargetType;
            
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
            var request = new Amazon.S3Control.Model.GetDataAccessRequest();
            
            if (cmdletContext.AccountId != null)
            {
                request.AccountId = cmdletContext.AccountId;
            }
            if (cmdletContext.DurationSecond != null)
            {
                request.DurationSeconds = cmdletContext.DurationSecond.Value;
            }
            if (cmdletContext.Permission != null)
            {
                request.Permission = cmdletContext.Permission;
            }
            if (cmdletContext.Privilege != null)
            {
                request.Privilege = cmdletContext.Privilege;
            }
            if (cmdletContext.Target != null)
            {
                request.Target = cmdletContext.Target;
            }
            if (cmdletContext.TargetType != null)
            {
                request.TargetType = cmdletContext.TargetType;
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
        
        private Amazon.S3Control.Model.GetDataAccessResponse CallAWSServiceOperation(IAmazonS3Control client, Amazon.S3Control.Model.GetDataAccessRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon S3 Control", "GetDataAccess");
            try
            {
                #if DESKTOP
                return client.GetDataAccess(request);
                #elif CORECLR
                return client.GetDataAccessAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? DurationSecond { get; set; }
            public Amazon.S3Control.Permission Permission { get; set; }
            public Amazon.S3Control.Privilege Privilege { get; set; }
            public System.String Target { get; set; }
            public Amazon.S3Control.S3PrefixType TargetType { get; set; }
            public System.Func<Amazon.S3Control.Model.GetDataAccessResponse, GetS3CDataAccessCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
