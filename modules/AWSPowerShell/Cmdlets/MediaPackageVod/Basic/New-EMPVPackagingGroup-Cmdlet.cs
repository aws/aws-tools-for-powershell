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
using Amazon.MediaPackageVod;
using Amazon.MediaPackageVod.Model;

namespace Amazon.PowerShell.Cmdlets.EMPV
{
    /// <summary>
    /// Creates a new MediaPackage VOD PackagingGroup resource.
    /// </summary>
    [Cmdlet("New", "EMPVPackagingGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MediaPackageVod.Model.CreatePackagingGroupResponse")]
    [AWSCmdlet("Calls the AWS Elemental MediaPackage VOD CreatePackagingGroup API operation.", Operation = new[] {"CreatePackagingGroup"}, SelectReturnType = typeof(Amazon.MediaPackageVod.Model.CreatePackagingGroupResponse))]
    [AWSCmdletOutput("Amazon.MediaPackageVod.Model.CreatePackagingGroupResponse",
        "This cmdlet returns an Amazon.MediaPackageVod.Model.CreatePackagingGroupResponse object containing multiple properties."
    )]
    public partial class NewEMPVPackagingGroupCmdlet : AmazonMediaPackageVodClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Authorization_CdnIdentifierSecret
        /// <summary>
        /// <para>
        /// The Amazon Resource Name (ARN) for
        /// the secret in AWS Secrets Manager that is used for CDN authorization.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Authorization_CdnIdentifierSecret { get; set; }
        #endregion
        
        #region Parameter Id
        /// <summary>
        /// <para>
        /// The ID of the PackagingGroup.
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
        public System.String Id { get; set; }
        #endregion
        
        #region Parameter EgressAccessLogs_LogGroupName
        /// <summary>
        /// <para>
        /// Customize the log group name.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EgressAccessLogs_LogGroupName { get; set; }
        #endregion
        
        #region Parameter Authorization_SecretsRoleArn
        /// <summary>
        /// <para>
        /// The Amazon Resource Name (ARN) for the
        /// IAM role that allows MediaPackage to communicate with AWS Secrets Manager.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Authorization_SecretsRoleArn { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MediaPackageVod.Model.CreatePackagingGroupResponse).
        /// Specifying the name of a property of type Amazon.MediaPackageVod.Model.CreatePackagingGroupResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Id), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EMPVPackagingGroup (CreatePackagingGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MediaPackageVod.Model.CreatePackagingGroupResponse, NewEMPVPackagingGroupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Authorization_CdnIdentifierSecret = this.Authorization_CdnIdentifierSecret;
            context.Authorization_SecretsRoleArn = this.Authorization_SecretsRoleArn;
            context.EgressAccessLogs_LogGroupName = this.EgressAccessLogs_LogGroupName;
            context.Id = this.Id;
            #if MODULAR
            if (this.Id == null && ParameterWasBound(nameof(this.Id)))
            {
                WriteWarning("You are passing $null as a value for parameter Id which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            var request = new Amazon.MediaPackageVod.Model.CreatePackagingGroupRequest();
            
            
             // populate Authorization
            var requestAuthorizationIsNull = true;
            request.Authorization = new Amazon.MediaPackageVod.Model.Authorization();
            System.String requestAuthorization_authorization_CdnIdentifierSecret = null;
            if (cmdletContext.Authorization_CdnIdentifierSecret != null)
            {
                requestAuthorization_authorization_CdnIdentifierSecret = cmdletContext.Authorization_CdnIdentifierSecret;
            }
            if (requestAuthorization_authorization_CdnIdentifierSecret != null)
            {
                request.Authorization.CdnIdentifierSecret = requestAuthorization_authorization_CdnIdentifierSecret;
                requestAuthorizationIsNull = false;
            }
            System.String requestAuthorization_authorization_SecretsRoleArn = null;
            if (cmdletContext.Authorization_SecretsRoleArn != null)
            {
                requestAuthorization_authorization_SecretsRoleArn = cmdletContext.Authorization_SecretsRoleArn;
            }
            if (requestAuthorization_authorization_SecretsRoleArn != null)
            {
                request.Authorization.SecretsRoleArn = requestAuthorization_authorization_SecretsRoleArn;
                requestAuthorizationIsNull = false;
            }
             // determine if request.Authorization should be set to null
            if (requestAuthorizationIsNull)
            {
                request.Authorization = null;
            }
            
             // populate EgressAccessLogs
            var requestEgressAccessLogsIsNull = true;
            request.EgressAccessLogs = new Amazon.MediaPackageVod.Model.EgressAccessLogs();
            System.String requestEgressAccessLogs_egressAccessLogs_LogGroupName = null;
            if (cmdletContext.EgressAccessLogs_LogGroupName != null)
            {
                requestEgressAccessLogs_egressAccessLogs_LogGroupName = cmdletContext.EgressAccessLogs_LogGroupName;
            }
            if (requestEgressAccessLogs_egressAccessLogs_LogGroupName != null)
            {
                request.EgressAccessLogs.LogGroupName = requestEgressAccessLogs_egressAccessLogs_LogGroupName;
                requestEgressAccessLogsIsNull = false;
            }
             // determine if request.EgressAccessLogs should be set to null
            if (requestEgressAccessLogsIsNull)
            {
                request.EgressAccessLogs = null;
            }
            if (cmdletContext.Id != null)
            {
                request.Id = cmdletContext.Id;
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
        
        private Amazon.MediaPackageVod.Model.CreatePackagingGroupResponse CallAWSServiceOperation(IAmazonMediaPackageVod client, Amazon.MediaPackageVod.Model.CreatePackagingGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Elemental MediaPackage VOD", "CreatePackagingGroup");
            try
            {
                #if DESKTOP
                return client.CreatePackagingGroup(request);
                #elif CORECLR
                return client.CreatePackagingGroupAsync(request).GetAwaiter().GetResult();
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
            public System.String Authorization_CdnIdentifierSecret { get; set; }
            public System.String Authorization_SecretsRoleArn { get; set; }
            public System.String EgressAccessLogs_LogGroupName { get; set; }
            public System.String Id { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.MediaPackageVod.Model.CreatePackagingGroupResponse, NewEMPVPackagingGroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
