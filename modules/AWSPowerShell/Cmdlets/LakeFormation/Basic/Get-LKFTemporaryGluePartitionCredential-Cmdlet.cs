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
using Amazon.LakeFormation;
using Amazon.LakeFormation.Model;

namespace Amazon.PowerShell.Cmdlets.LKF
{
    /// <summary>
    /// This API is identical to <code>GetTemporaryTableCredentials</code> except that this
    /// is used when the target Data Catalog resource is of type Partition. Lake Formation
    /// restricts the permission of the vended credentials with the same scope down policy
    /// which restricts access to a single Amazon S3 prefix.
    /// </summary>
    [Cmdlet("Get", "LKFTemporaryGluePartitionCredential")]
    [OutputType("Amazon.LakeFormation.Model.GetTemporaryGluePartitionCredentialsResponse")]
    [AWSCmdlet("Calls the AWS Lake Formation GetTemporaryGluePartitionCredentials API operation.", Operation = new[] {"GetTemporaryGluePartitionCredentials"}, SelectReturnType = typeof(Amazon.LakeFormation.Model.GetTemporaryGluePartitionCredentialsResponse))]
    [AWSCmdletOutput("Amazon.LakeFormation.Model.GetTemporaryGluePartitionCredentialsResponse",
        "This cmdlet returns an Amazon.LakeFormation.Model.GetTemporaryGluePartitionCredentialsResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetLKFTemporaryGluePartitionCredentialCmdlet : AmazonLakeFormationClientCmdlet, IExecutor
    {
        
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
        
        #region Parameter SupportedPermissionType
        /// <summary>
        /// <para>
        /// <para>A list of supported permission types for the partition. Valid values are <code>COLUMN_PERMISSION</code>
        /// and <code>CELL_FILTER_PERMISSION</code>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("SupportedPermissionTypes")]
        public System.String[] SupportedPermissionType { get; set; }
        #endregion
        
        #region Parameter TableArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the partitions' table.</para>
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
        
        #region Parameter Partition_Value
        /// <summary>
        /// <para>
        /// <para>The list of partition values.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Partition_Values")]
        public System.String[] Partition_Value { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LakeFormation.Model.GetTemporaryGluePartitionCredentialsResponse).
        /// Specifying the name of a property of type Amazon.LakeFormation.Model.GetTemporaryGluePartitionCredentialsResponse will result in that property being returned.
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
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LakeFormation.Model.GetTemporaryGluePartitionCredentialsResponse, GetLKFTemporaryGluePartitionCredentialCmdlet>(Select) ??
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
            if (this.Partition_Value != null)
            {
                context.Partition_Value = new List<System.String>(this.Partition_Value);
            }
            #if MODULAR
            if (this.Partition_Value == null && ParameterWasBound(nameof(this.Partition_Value)))
            {
                WriteWarning("You are passing $null as a value for parameter Partition_Value which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Permission != null)
            {
                context.Permission = new List<System.String>(this.Permission);
            }
            if (this.SupportedPermissionType != null)
            {
                context.SupportedPermissionType = new List<System.String>(this.SupportedPermissionType);
            }
            #if MODULAR
            if (this.SupportedPermissionType == null && ParameterWasBound(nameof(this.SupportedPermissionType)))
            {
                WriteWarning("You are passing $null as a value for parameter SupportedPermissionType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            var request = new Amazon.LakeFormation.Model.GetTemporaryGluePartitionCredentialsRequest();
            
            
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
            
             // populate Partition
            var requestPartitionIsNull = true;
            request.Partition = new Amazon.LakeFormation.Model.PartitionValueList();
            List<System.String> requestPartition_partition_Value = null;
            if (cmdletContext.Partition_Value != null)
            {
                requestPartition_partition_Value = cmdletContext.Partition_Value;
            }
            if (requestPartition_partition_Value != null)
            {
                request.Partition.Values = requestPartition_partition_Value;
                requestPartitionIsNull = false;
            }
             // determine if request.Partition should be set to null
            if (requestPartitionIsNull)
            {
                request.Partition = null;
            }
            if (cmdletContext.Permission != null)
            {
                request.Permissions = cmdletContext.Permission;
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
        
        private Amazon.LakeFormation.Model.GetTemporaryGluePartitionCredentialsResponse CallAWSServiceOperation(IAmazonLakeFormation client, Amazon.LakeFormation.Model.GetTemporaryGluePartitionCredentialsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Lake Formation", "GetTemporaryGluePartitionCredentials");
            try
            {
                #if DESKTOP
                return client.GetTemporaryGluePartitionCredentials(request);
                #elif CORECLR
                return client.GetTemporaryGluePartitionCredentialsAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> Partition_Value { get; set; }
            public List<System.String> Permission { get; set; }
            public List<System.String> SupportedPermissionType { get; set; }
            public System.String TableArn { get; set; }
            public System.Func<Amazon.LakeFormation.Model.GetTemporaryGluePartitionCredentialsResponse, GetLKFTemporaryGluePartitionCredentialCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
