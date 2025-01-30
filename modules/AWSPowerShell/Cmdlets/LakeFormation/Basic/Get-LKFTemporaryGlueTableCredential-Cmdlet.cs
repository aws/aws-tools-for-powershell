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
using Amazon.LakeFormation;
using Amazon.LakeFormation.Model;

namespace Amazon.PowerShell.Cmdlets.LKF
{
    /// <summary>
    /// Allows a caller in a secure environment to assume a role with permission to access
    /// Amazon S3. In order to vend such credentials, Lake Formation assumes the role associated
    /// with a registered location, for example an Amazon S3 bucket, with a scope down policy
    /// which restricts the access to a single prefix.
    /// 
    ///  
    /// <para>
    /// To call this API, the role that the service assumes must have <c>lakeformation:GetDataAccess</c>
    /// permission on the resource.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "LKFTemporaryGlueTableCredential")]
    [OutputType("Amazon.LakeFormation.Model.GetTemporaryGlueTableCredentialsResponse")]
    [AWSCmdlet("Calls the AWS Lake Formation GetTemporaryGlueTableCredentials API operation.", Operation = new[] {"GetTemporaryGlueTableCredentials"}, SelectReturnType = typeof(Amazon.LakeFormation.Model.GetTemporaryGlueTableCredentialsResponse))]
    [AWSCmdletOutput("Amazon.LakeFormation.Model.GetTemporaryGlueTableCredentialsResponse",
        "This cmdlet returns an Amazon.LakeFormation.Model.GetTemporaryGlueTableCredentialsResponse object containing multiple properties."
    )]
    public partial class GetLKFTemporaryGlueTableCredentialCmdlet : AmazonLakeFormationClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AuditContext_AdditionalAuditContext
        /// <summary>
        /// <para>
        /// <para>The filter engine can populate the 'AdditionalAuditContext' information with the request
        /// ID for you to track. This information will be displayed in CloudTrail log in your
        /// account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AuditContext_AdditionalAuditContext { get; set; }
        #endregion
        
        #region Parameter QuerySessionContext_AdditionalContext
        /// <summary>
        /// <para>
        /// <para>An opaque string-string map passed by the query engine.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable QuerySessionContext_AdditionalContext { get; set; }
        #endregion
        
        #region Parameter QuerySessionContext_ClusterId
        /// <summary>
        /// <para>
        /// <para>An identifier string for the consumer cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String QuerySessionContext_ClusterId { get; set; }
        #endregion
        
        #region Parameter DurationSecond
        /// <summary>
        /// <para>
        /// <para>The time period, between 900 and 21,600 seconds, for the timeout of the temporary
        /// credentials.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DurationSeconds")]
        public System.Int32? DurationSecond { get; set; }
        #endregion
        
        #region Parameter Permission
        /// <summary>
        /// <para>
        /// <para>Filters the request based on the user having been granted a list of specified permissions
        /// on the requested resource(s).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Permissions")]
        public System.String[] Permission { get; set; }
        #endregion
        
        #region Parameter QuerySessionContext_QueryAuthorizationId
        /// <summary>
        /// <para>
        /// <para>A cryptographically generated query identifier generated by Glue or Lake Formation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String QuerySessionContext_QueryAuthorizationId { get; set; }
        #endregion
        
        #region Parameter QuerySessionContext_QueryId
        /// <summary>
        /// <para>
        /// <para>A unique identifier generated by the query engine for the query.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String QuerySessionContext_QueryId { get; set; }
        #endregion
        
        #region Parameter QuerySessionContext_QueryStartTime
        /// <summary>
        /// <para>
        /// <para>A timestamp provided by the query engine for when the query started.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? QuerySessionContext_QueryStartTime { get; set; }
        #endregion
        
        #region Parameter S3Path
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 path for the table.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String S3Path { get; set; }
        #endregion
        
        #region Parameter SupportedPermissionType
        /// <summary>
        /// <para>
        /// <para>A list of supported permission types for the table. Valid values are <c>COLUMN_PERMISSION</c>
        /// and <c>CELL_FILTER_PERMISSION</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SupportedPermissionTypes")]
        public System.String[] SupportedPermissionType { get; set; }
        #endregion
        
        #region Parameter TableArn
        /// <summary>
        /// <para>
        /// <para>The ARN identifying a table in the Data Catalog for the temporary credentials request.</para>
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
        public System.String TableArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LakeFormation.Model.GetTemporaryGlueTableCredentialsResponse).
        /// Specifying the name of a property of type Amazon.LakeFormation.Model.GetTemporaryGlueTableCredentialsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the TableArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^TableArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^TableArn' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LakeFormation.Model.GetTemporaryGlueTableCredentialsResponse, GetLKFTemporaryGlueTableCredentialCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.TableArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AuditContext_AdditionalAuditContext = this.AuditContext_AdditionalAuditContext;
            context.DurationSecond = this.DurationSecond;
            if (this.Permission != null)
            {
                context.Permission = new List<System.String>(this.Permission);
            }
            if (this.QuerySessionContext_AdditionalContext != null)
            {
                context.QuerySessionContext_AdditionalContext = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.QuerySessionContext_AdditionalContext.Keys)
                {
                    context.QuerySessionContext_AdditionalContext.Add((String)hashKey, (System.String)(this.QuerySessionContext_AdditionalContext[hashKey]));
                }
            }
            context.QuerySessionContext_ClusterId = this.QuerySessionContext_ClusterId;
            context.QuerySessionContext_QueryAuthorizationId = this.QuerySessionContext_QueryAuthorizationId;
            context.QuerySessionContext_QueryId = this.QuerySessionContext_QueryId;
            context.QuerySessionContext_QueryStartTime = this.QuerySessionContext_QueryStartTime;
            context.S3Path = this.S3Path;
            if (this.SupportedPermissionType != null)
            {
                context.SupportedPermissionType = new List<System.String>(this.SupportedPermissionType);
            }
            context.TableArn = this.TableArn;
            #if MODULAR
            if (this.TableArn == null && ParameterWasBound(nameof(this.TableArn)))
            {
                WriteWarning("You are passing $null as a value for parameter TableArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.LakeFormation.Model.GetTemporaryGlueTableCredentialsRequest();
            
            
             // populate AuditContext
            var requestAuditContextIsNull = true;
            request.AuditContext = new Amazon.LakeFormation.Model.AuditContext();
            System.String requestAuditContext_auditContext_AdditionalAuditContext = null;
            if (cmdletContext.AuditContext_AdditionalAuditContext != null)
            {
                requestAuditContext_auditContext_AdditionalAuditContext = cmdletContext.AuditContext_AdditionalAuditContext;
            }
            if (requestAuditContext_auditContext_AdditionalAuditContext != null)
            {
                request.AuditContext.AdditionalAuditContext = requestAuditContext_auditContext_AdditionalAuditContext;
                requestAuditContextIsNull = false;
            }
             // determine if request.AuditContext should be set to null
            if (requestAuditContextIsNull)
            {
                request.AuditContext = null;
            }
            if (cmdletContext.DurationSecond != null)
            {
                request.DurationSeconds = cmdletContext.DurationSecond.Value;
            }
            if (cmdletContext.Permission != null)
            {
                request.Permissions = cmdletContext.Permission;
            }
            
             // populate QuerySessionContext
            var requestQuerySessionContextIsNull = true;
            request.QuerySessionContext = new Amazon.LakeFormation.Model.QuerySessionContext();
            Dictionary<System.String, System.String> requestQuerySessionContext_querySessionContext_AdditionalContext = null;
            if (cmdletContext.QuerySessionContext_AdditionalContext != null)
            {
                requestQuerySessionContext_querySessionContext_AdditionalContext = cmdletContext.QuerySessionContext_AdditionalContext;
            }
            if (requestQuerySessionContext_querySessionContext_AdditionalContext != null)
            {
                request.QuerySessionContext.AdditionalContext = requestQuerySessionContext_querySessionContext_AdditionalContext;
                requestQuerySessionContextIsNull = false;
            }
            System.String requestQuerySessionContext_querySessionContext_ClusterId = null;
            if (cmdletContext.QuerySessionContext_ClusterId != null)
            {
                requestQuerySessionContext_querySessionContext_ClusterId = cmdletContext.QuerySessionContext_ClusterId;
            }
            if (requestQuerySessionContext_querySessionContext_ClusterId != null)
            {
                request.QuerySessionContext.ClusterId = requestQuerySessionContext_querySessionContext_ClusterId;
                requestQuerySessionContextIsNull = false;
            }
            System.String requestQuerySessionContext_querySessionContext_QueryAuthorizationId = null;
            if (cmdletContext.QuerySessionContext_QueryAuthorizationId != null)
            {
                requestQuerySessionContext_querySessionContext_QueryAuthorizationId = cmdletContext.QuerySessionContext_QueryAuthorizationId;
            }
            if (requestQuerySessionContext_querySessionContext_QueryAuthorizationId != null)
            {
                request.QuerySessionContext.QueryAuthorizationId = requestQuerySessionContext_querySessionContext_QueryAuthorizationId;
                requestQuerySessionContextIsNull = false;
            }
            System.String requestQuerySessionContext_querySessionContext_QueryId = null;
            if (cmdletContext.QuerySessionContext_QueryId != null)
            {
                requestQuerySessionContext_querySessionContext_QueryId = cmdletContext.QuerySessionContext_QueryId;
            }
            if (requestQuerySessionContext_querySessionContext_QueryId != null)
            {
                request.QuerySessionContext.QueryId = requestQuerySessionContext_querySessionContext_QueryId;
                requestQuerySessionContextIsNull = false;
            }
            System.DateTime? requestQuerySessionContext_querySessionContext_QueryStartTime = null;
            if (cmdletContext.QuerySessionContext_QueryStartTime != null)
            {
                requestQuerySessionContext_querySessionContext_QueryStartTime = cmdletContext.QuerySessionContext_QueryStartTime.Value;
            }
            if (requestQuerySessionContext_querySessionContext_QueryStartTime != null)
            {
                request.QuerySessionContext.QueryStartTime = requestQuerySessionContext_querySessionContext_QueryStartTime.Value;
                requestQuerySessionContextIsNull = false;
            }
             // determine if request.QuerySessionContext should be set to null
            if (requestQuerySessionContextIsNull)
            {
                request.QuerySessionContext = null;
            }
            if (cmdletContext.S3Path != null)
            {
                request.S3Path = cmdletContext.S3Path;
            }
            if (cmdletContext.SupportedPermissionType != null)
            {
                request.SupportedPermissionTypes = cmdletContext.SupportedPermissionType;
            }
            if (cmdletContext.TableArn != null)
            {
                request.TableArn = cmdletContext.TableArn;
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
        
        private Amazon.LakeFormation.Model.GetTemporaryGlueTableCredentialsResponse CallAWSServiceOperation(IAmazonLakeFormation client, Amazon.LakeFormation.Model.GetTemporaryGlueTableCredentialsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Lake Formation", "GetTemporaryGlueTableCredentials");
            try
            {
                #if DESKTOP
                return client.GetTemporaryGlueTableCredentials(request);
                #elif CORECLR
                return client.GetTemporaryGlueTableCredentialsAsync(request).GetAwaiter().GetResult();
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
            public System.String AuditContext_AdditionalAuditContext { get; set; }
            public System.Int32? DurationSecond { get; set; }
            public List<System.String> Permission { get; set; }
            public Dictionary<System.String, System.String> QuerySessionContext_AdditionalContext { get; set; }
            public System.String QuerySessionContext_ClusterId { get; set; }
            public System.String QuerySessionContext_QueryAuthorizationId { get; set; }
            public System.String QuerySessionContext_QueryId { get; set; }
            public System.DateTime? QuerySessionContext_QueryStartTime { get; set; }
            public System.String S3Path { get; set; }
            public List<System.String> SupportedPermissionType { get; set; }
            public System.String TableArn { get; set; }
            public System.Func<Amazon.LakeFormation.Model.GetTemporaryGlueTableCredentialsResponse, GetLKFTemporaryGlueTableCredentialCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
