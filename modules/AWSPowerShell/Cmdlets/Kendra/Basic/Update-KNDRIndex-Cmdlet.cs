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
using Amazon.Kendra;
using Amazon.Kendra.Model;

namespace Amazon.PowerShell.Cmdlets.KNDR
{
    /// <summary>
    /// Updates an Amazon Kendra index.
    /// </summary>
    [Cmdlet("Update", "KNDRIndex", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Kendra UpdateIndex API operation.", Operation = new[] {"UpdateIndex"}, SelectReturnType = typeof(Amazon.Kendra.Model.UpdateIndexResponse))]
    [AWSCmdletOutput("None or Amazon.Kendra.Model.UpdateIndexResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Kendra.Model.UpdateIndexResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateKNDRIndexCmdlet : AmazonKendraClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A new description for the index.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DocumentMetadataConfigurationUpdate
        /// <summary>
        /// <para>
        /// <para>The document metadata configuration you want to update for the index. Document metadata
        /// are fields or attributes associated with your documents. For example, the company
        /// department name associated with each document.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DocumentMetadataConfigurationUpdates")]
        public Amazon.Kendra.Model.DocumentMetadataConfiguration[] DocumentMetadataConfigurationUpdate { get; set; }
        #endregion
        
        #region Parameter Id
        /// <summary>
        /// <para>
        /// <para>The identifier of the index you want to update.</para>
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
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>A new name for the index.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter CapacityUnits_QueryCapacityUnit
        /// <summary>
        /// <para>
        /// <para>The amount of extra query capacity for an index and <a href="https://docs.aws.amazon.com/kendra/latest/dg/API_GetQuerySuggestions.html">GetQuerySuggestions</a>
        /// capacity.</para><para>A single extra capacity unit for an index provides 0.1 queries per second or approximately
        /// 8,000 queries per day. You can add up to 100 extra capacity units.</para><para><c>GetQuerySuggestions</c> capacity is five times the provisioned query capacity
        /// for an index, or the base capacity of 2.5 calls per second, whichever is higher. For
        /// example, the base capacity for an index is 0.1 queries per second, and <c>GetQuerySuggestions</c>
        /// capacity has a base of 2.5 calls per second. If you add another 0.1 queries per second
        /// to total 0.2 queries per second for an index, the <c>GetQuerySuggestions</c> capacity
        /// is 2.5 calls per second (higher than five times 0.2 queries per second).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CapacityUnits_QueryCapacityUnits")]
        public System.Int32? CapacityUnits_QueryCapacityUnit { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>An Identity and Access Management (IAM) role that gives Amazon Kendra permission to
        /// access Amazon CloudWatch logs and metrics.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter CapacityUnits_StorageCapacityUnit
        /// <summary>
        /// <para>
        /// <para>The amount of extra storage capacity for an index. A single capacity unit provides
        /// 30 GB of storage space or 100,000 documents, whichever is reached first. You can add
        /// up to 100 extra capacity units.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CapacityUnits_StorageCapacityUnits")]
        public System.Int32? CapacityUnits_StorageCapacityUnit { get; set; }
        #endregion
        
        #region Parameter UserContextPolicy
        /// <summary>
        /// <para>
        /// <para>The user context policy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Kendra.UserContextPolicy")]
        public Amazon.Kendra.UserContextPolicy UserContextPolicy { get; set; }
        #endregion
        
        #region Parameter UserGroupResolutionConfiguration_UserGroupResolutionMode
        /// <summary>
        /// <para>
        /// <para>The identity store provider (mode) you want to use to get users and groups. IAM Identity
        /// Center is currently the only available mode. Your users and groups must exist in an
        /// IAM Identity Center identity source in order to use this mode.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Kendra.UserGroupResolutionMode")]
        public Amazon.Kendra.UserGroupResolutionMode UserGroupResolutionConfiguration_UserGroupResolutionMode { get; set; }
        #endregion
        
        #region Parameter UserTokenConfiguration
        /// <summary>
        /// <para>
        /// <para>The user token configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("UserTokenConfigurations")]
        public Amazon.Kendra.Model.UserTokenConfiguration[] UserTokenConfiguration { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Kendra.Model.UpdateIndexResponse).
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-KNDRIndex (UpdateIndex)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Kendra.Model.UpdateIndexResponse, UpdateKNDRIndexCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CapacityUnits_QueryCapacityUnit = this.CapacityUnits_QueryCapacityUnit;
            context.CapacityUnits_StorageCapacityUnit = this.CapacityUnits_StorageCapacityUnit;
            context.Description = this.Description;
            if (this.DocumentMetadataConfigurationUpdate != null)
            {
                context.DocumentMetadataConfigurationUpdate = new List<Amazon.Kendra.Model.DocumentMetadataConfiguration>(this.DocumentMetadataConfigurationUpdate);
            }
            context.Id = this.Id;
            #if MODULAR
            if (this.Id == null && ParameterWasBound(nameof(this.Id)))
            {
                WriteWarning("You are passing $null as a value for parameter Id which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            context.RoleArn = this.RoleArn;
            context.UserContextPolicy = this.UserContextPolicy;
            context.UserGroupResolutionConfiguration_UserGroupResolutionMode = this.UserGroupResolutionConfiguration_UserGroupResolutionMode;
            if (this.UserTokenConfiguration != null)
            {
                context.UserTokenConfiguration = new List<Amazon.Kendra.Model.UserTokenConfiguration>(this.UserTokenConfiguration);
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
            var request = new Amazon.Kendra.Model.UpdateIndexRequest();
            
            
             // populate CapacityUnits
            var requestCapacityUnitsIsNull = true;
            request.CapacityUnits = new Amazon.Kendra.Model.CapacityUnitsConfiguration();
            System.Int32? requestCapacityUnits_capacityUnits_QueryCapacityUnit = null;
            if (cmdletContext.CapacityUnits_QueryCapacityUnit != null)
            {
                requestCapacityUnits_capacityUnits_QueryCapacityUnit = cmdletContext.CapacityUnits_QueryCapacityUnit.Value;
            }
            if (requestCapacityUnits_capacityUnits_QueryCapacityUnit != null)
            {
                request.CapacityUnits.QueryCapacityUnits = requestCapacityUnits_capacityUnits_QueryCapacityUnit.Value;
                requestCapacityUnitsIsNull = false;
            }
            System.Int32? requestCapacityUnits_capacityUnits_StorageCapacityUnit = null;
            if (cmdletContext.CapacityUnits_StorageCapacityUnit != null)
            {
                requestCapacityUnits_capacityUnits_StorageCapacityUnit = cmdletContext.CapacityUnits_StorageCapacityUnit.Value;
            }
            if (requestCapacityUnits_capacityUnits_StorageCapacityUnit != null)
            {
                request.CapacityUnits.StorageCapacityUnits = requestCapacityUnits_capacityUnits_StorageCapacityUnit.Value;
                requestCapacityUnitsIsNull = false;
            }
             // determine if request.CapacityUnits should be set to null
            if (requestCapacityUnitsIsNull)
            {
                request.CapacityUnits = null;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.DocumentMetadataConfigurationUpdate != null)
            {
                request.DocumentMetadataConfigurationUpdates = cmdletContext.DocumentMetadataConfigurationUpdate;
            }
            if (cmdletContext.Id != null)
            {
                request.Id = cmdletContext.Id;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
            }
            if (cmdletContext.UserContextPolicy != null)
            {
                request.UserContextPolicy = cmdletContext.UserContextPolicy;
            }
            
             // populate UserGroupResolutionConfiguration
            var requestUserGroupResolutionConfigurationIsNull = true;
            request.UserGroupResolutionConfiguration = new Amazon.Kendra.Model.UserGroupResolutionConfiguration();
            Amazon.Kendra.UserGroupResolutionMode requestUserGroupResolutionConfiguration_userGroupResolutionConfiguration_UserGroupResolutionMode = null;
            if (cmdletContext.UserGroupResolutionConfiguration_UserGroupResolutionMode != null)
            {
                requestUserGroupResolutionConfiguration_userGroupResolutionConfiguration_UserGroupResolutionMode = cmdletContext.UserGroupResolutionConfiguration_UserGroupResolutionMode;
            }
            if (requestUserGroupResolutionConfiguration_userGroupResolutionConfiguration_UserGroupResolutionMode != null)
            {
                request.UserGroupResolutionConfiguration.UserGroupResolutionMode = requestUserGroupResolutionConfiguration_userGroupResolutionConfiguration_UserGroupResolutionMode;
                requestUserGroupResolutionConfigurationIsNull = false;
            }
             // determine if request.UserGroupResolutionConfiguration should be set to null
            if (requestUserGroupResolutionConfigurationIsNull)
            {
                request.UserGroupResolutionConfiguration = null;
            }
            if (cmdletContext.UserTokenConfiguration != null)
            {
                request.UserTokenConfigurations = cmdletContext.UserTokenConfiguration;
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
        
        private Amazon.Kendra.Model.UpdateIndexResponse CallAWSServiceOperation(IAmazonKendra client, Amazon.Kendra.Model.UpdateIndexRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Kendra", "UpdateIndex");
            try
            {
                #if DESKTOP
                return client.UpdateIndex(request);
                #elif CORECLR
                return client.UpdateIndexAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? CapacityUnits_QueryCapacityUnit { get; set; }
            public System.Int32? CapacityUnits_StorageCapacityUnit { get; set; }
            public System.String Description { get; set; }
            public List<Amazon.Kendra.Model.DocumentMetadataConfiguration> DocumentMetadataConfigurationUpdate { get; set; }
            public System.String Id { get; set; }
            public System.String Name { get; set; }
            public System.String RoleArn { get; set; }
            public Amazon.Kendra.UserContextPolicy UserContextPolicy { get; set; }
            public Amazon.Kendra.UserGroupResolutionMode UserGroupResolutionConfiguration_UserGroupResolutionMode { get; set; }
            public List<Amazon.Kendra.Model.UserTokenConfiguration> UserTokenConfiguration { get; set; }
            public System.Func<Amazon.Kendra.Model.UpdateIndexResponse, UpdateKNDRIndexCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
