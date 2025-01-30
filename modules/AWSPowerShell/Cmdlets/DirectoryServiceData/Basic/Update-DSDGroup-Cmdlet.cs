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
using Amazon.DirectoryServiceData;
using Amazon.DirectoryServiceData.Model;

namespace Amazon.PowerShell.Cmdlets.DSD
{
    /// <summary>
    /// Updates group information.
    /// </summary>
    [Cmdlet("Update", "DSDGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Directory Service Data UpdateGroup API operation.", Operation = new[] {"UpdateGroup"}, SelectReturnType = typeof(Amazon.DirectoryServiceData.Model.UpdateGroupResponse))]
    [AWSCmdletOutput("None or Amazon.DirectoryServiceData.Model.UpdateGroupResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.DirectoryServiceData.Model.UpdateGroupResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateDSDGroupCmdlet : AmazonDirectoryServiceDataClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DirectoryId
        /// <summary>
        /// <para>
        /// <para> The identifier (ID) of the directory that's associated with the group. </para>
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
        public System.String DirectoryId { get; set; }
        #endregion
        
        #region Parameter GroupScope
        /// <summary>
        /// <para>
        /// <para> The scope of the AD group. For details, see <a href="https://learn.microsoft.com/en-us/windows-server/identity/ad-ds/manage/understand-security-groups#group-scope">Active
        /// Directory security groups</a>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DirectoryServiceData.GroupScope")]
        public Amazon.DirectoryServiceData.GroupScope GroupScope { get; set; }
        #endregion
        
        #region Parameter GroupType
        /// <summary>
        /// <para>
        /// <para> The AD group type. For details, see <a href="https://learn.microsoft.com/en-us/windows-server/identity/ad-ds/manage/understand-security-groups#how-active-directory-security-groups-work">Active
        /// Directory security group type</a>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DirectoryServiceData.GroupType")]
        public Amazon.DirectoryServiceData.GroupType GroupType { get; set; }
        #endregion
        
        #region Parameter OtherAttribute
        /// <summary>
        /// <para>
        /// <para> An expression that defines one or more attributes with the data type and the value
        /// of each attribute. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OtherAttributes")]
        public System.Collections.Hashtable OtherAttribute { get; set; }
        #endregion
        
        #region Parameter SAMAccountName
        /// <summary>
        /// <para>
        /// <para> The name of the group. </para>
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
        public System.String SAMAccountName { get; set; }
        #endregion
        
        #region Parameter UpdateType
        /// <summary>
        /// <para>
        /// <para> The type of update to be performed. If no value exists for the attribute, use <c>ADD</c>.
        /// Otherwise, use <c>REPLACE</c> to change an attribute value or <c>REMOVE</c> to clear
        /// the attribute value. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DirectoryServiceData.UpdateType")]
        public Amazon.DirectoryServiceData.UpdateType UpdateType { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para> A unique and case-sensitive identifier that you provide to make sure the idempotency
        /// of the request, so multiple identical calls have the same effect as one single call.
        /// </para><para> A client token is valid for 8 hours after the first request that uses it completes.
        /// After 8 hours, any request with the same client token is treated as a new request.
        /// If the request succeeds, any future uses of that token will be idempotent for another
        /// 8 hours. </para><para> If you submit a request with the same client token but change one of the other parameters
        /// within the 8-hour idempotency window, Directory Service Data returns an <c>ConflictException</c>.
        /// </para><note><para> This parameter is optional when using the CLI or SDK. </para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DirectoryServiceData.Model.UpdateGroupResponse).
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-DSDGroup (UpdateGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DirectoryServiceData.Model.UpdateGroupResponse, UpdateDSDGroupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.DirectoryId = this.DirectoryId;
            #if MODULAR
            if (this.DirectoryId == null && ParameterWasBound(nameof(this.DirectoryId)))
            {
                WriteWarning("You are passing $null as a value for parameter DirectoryId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.GroupScope = this.GroupScope;
            context.GroupType = this.GroupType;
            if (this.OtherAttribute != null)
            {
                context.OtherAttribute = new Dictionary<System.String, Amazon.DirectoryServiceData.Model.AttributeValue>(StringComparer.Ordinal);
                foreach (var hashKey in this.OtherAttribute.Keys)
                {
                    context.OtherAttribute.Add((String)hashKey, (Amazon.DirectoryServiceData.Model.AttributeValue)(this.OtherAttribute[hashKey]));
                }
            }
            context.SAMAccountName = this.SAMAccountName;
            #if MODULAR
            if (this.SAMAccountName == null && ParameterWasBound(nameof(this.SAMAccountName)))
            {
                WriteWarning("You are passing $null as a value for parameter SAMAccountName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.UpdateType = this.UpdateType;
            
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
            var request = new Amazon.DirectoryServiceData.Model.UpdateGroupRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.DirectoryId != null)
            {
                request.DirectoryId = cmdletContext.DirectoryId;
            }
            if (cmdletContext.GroupScope != null)
            {
                request.GroupScope = cmdletContext.GroupScope;
            }
            if (cmdletContext.GroupType != null)
            {
                request.GroupType = cmdletContext.GroupType;
            }
            if (cmdletContext.OtherAttribute != null)
            {
                request.OtherAttributes = cmdletContext.OtherAttribute;
            }
            if (cmdletContext.SAMAccountName != null)
            {
                request.SAMAccountName = cmdletContext.SAMAccountName;
            }
            if (cmdletContext.UpdateType != null)
            {
                request.UpdateType = cmdletContext.UpdateType;
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
        
        private Amazon.DirectoryServiceData.Model.UpdateGroupResponse CallAWSServiceOperation(IAmazonDirectoryServiceData client, Amazon.DirectoryServiceData.Model.UpdateGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Directory Service Data", "UpdateGroup");
            try
            {
                #if DESKTOP
                return client.UpdateGroup(request);
                #elif CORECLR
                return client.UpdateGroupAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String DirectoryId { get; set; }
            public Amazon.DirectoryServiceData.GroupScope GroupScope { get; set; }
            public Amazon.DirectoryServiceData.GroupType GroupType { get; set; }
            public Dictionary<System.String, Amazon.DirectoryServiceData.Model.AttributeValue> OtherAttribute { get; set; }
            public System.String SAMAccountName { get; set; }
            public Amazon.DirectoryServiceData.UpdateType UpdateType { get; set; }
            public System.Func<Amazon.DirectoryServiceData.Model.UpdateGroupResponse, UpdateDSDGroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
