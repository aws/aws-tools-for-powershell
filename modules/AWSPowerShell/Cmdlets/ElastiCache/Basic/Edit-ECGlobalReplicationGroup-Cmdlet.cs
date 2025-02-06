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
using Amazon.ElastiCache;
using Amazon.ElastiCache.Model;

namespace Amazon.PowerShell.Cmdlets.EC
{
    /// <summary>
    /// Modifies the settings for a Global datastore.
    /// </summary>
    [Cmdlet("Edit", "ECGlobalReplicationGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ElastiCache.Model.GlobalReplicationGroup")]
    [AWSCmdlet("Calls the Amazon ElastiCache ModifyGlobalReplicationGroup API operation.", Operation = new[] {"ModifyGlobalReplicationGroup"}, SelectReturnType = typeof(Amazon.ElastiCache.Model.ModifyGlobalReplicationGroupResponse))]
    [AWSCmdletOutput("Amazon.ElastiCache.Model.GlobalReplicationGroup or Amazon.ElastiCache.Model.ModifyGlobalReplicationGroupResponse",
        "This cmdlet returns an Amazon.ElastiCache.Model.GlobalReplicationGroup object.",
        "The service call response (type Amazon.ElastiCache.Model.ModifyGlobalReplicationGroupResponse) can be returned by specifying '-Select *'."
    )]
    public partial class EditECGlobalReplicationGroupCmdlet : AmazonElastiCacheClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ApplyImmediately
        /// <summary>
        /// <para>
        /// <para>This parameter causes the modifications in this request and any pending modifications
        /// to be applied, asynchronously and as soon as possible. Modifications to Global Replication
        /// Groups cannot be requested to be applied in PreferredMaintenceWindow. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Boolean? ApplyImmediately { get; set; }
        #endregion
        
        #region Parameter AutomaticFailoverEnabled
        /// <summary>
        /// <para>
        /// <para>Determines whether a read replica is automatically promoted to read/write primary
        /// if the existing primary encounters a failure. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AutomaticFailoverEnabled { get; set; }
        #endregion
        
        #region Parameter CacheNodeType
        /// <summary>
        /// <para>
        /// <para>A valid cache node type that you want to scale this Global datastore to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CacheNodeType { get; set; }
        #endregion
        
        #region Parameter CacheParameterGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the cache parameter group to use with the Global datastore. It must be
        /// compatible with the major engine version used by the Global datastore.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CacheParameterGroupName { get; set; }
        #endregion
        
        #region Parameter Engine
        /// <summary>
        /// <para>
        /// <para>Modifies the engine listed in a global replication group message. The options are
        /// redis, memcached or valkey.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Engine { get; set; }
        #endregion
        
        #region Parameter EngineVersion
        /// <summary>
        /// <para>
        /// <para>The upgraded version of the cache engine to be run on the clusters in the Global datastore.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EngineVersion { get; set; }
        #endregion
        
        #region Parameter GlobalReplicationGroupDescription
        /// <summary>
        /// <para>
        /// <para>A description of the Global datastore</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String GlobalReplicationGroupDescription { get; set; }
        #endregion
        
        #region Parameter GlobalReplicationGroupId
        /// <summary>
        /// <para>
        /// <para>The name of the Global datastore</para>
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
        public System.String GlobalReplicationGroupId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'GlobalReplicationGroup'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElastiCache.Model.ModifyGlobalReplicationGroupResponse).
        /// Specifying the name of a property of type Amazon.ElastiCache.Model.ModifyGlobalReplicationGroupResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "GlobalReplicationGroup";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.GlobalReplicationGroupId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-ECGlobalReplicationGroup (ModifyGlobalReplicationGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ElastiCache.Model.ModifyGlobalReplicationGroupResponse, EditECGlobalReplicationGroupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ApplyImmediately = this.ApplyImmediately;
            #if MODULAR
            if (this.ApplyImmediately == null && ParameterWasBound(nameof(this.ApplyImmediately)))
            {
                WriteWarning("You are passing $null as a value for parameter ApplyImmediately which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AutomaticFailoverEnabled = this.AutomaticFailoverEnabled;
            context.CacheNodeType = this.CacheNodeType;
            context.CacheParameterGroupName = this.CacheParameterGroupName;
            context.Engine = this.Engine;
            context.EngineVersion = this.EngineVersion;
            context.GlobalReplicationGroupDescription = this.GlobalReplicationGroupDescription;
            context.GlobalReplicationGroupId = this.GlobalReplicationGroupId;
            #if MODULAR
            if (this.GlobalReplicationGroupId == null && ParameterWasBound(nameof(this.GlobalReplicationGroupId)))
            {
                WriteWarning("You are passing $null as a value for parameter GlobalReplicationGroupId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ElastiCache.Model.ModifyGlobalReplicationGroupRequest();
            
            if (cmdletContext.ApplyImmediately != null)
            {
                request.ApplyImmediately = cmdletContext.ApplyImmediately.Value;
            }
            if (cmdletContext.AutomaticFailoverEnabled != null)
            {
                request.AutomaticFailoverEnabled = cmdletContext.AutomaticFailoverEnabled.Value;
            }
            if (cmdletContext.CacheNodeType != null)
            {
                request.CacheNodeType = cmdletContext.CacheNodeType;
            }
            if (cmdletContext.CacheParameterGroupName != null)
            {
                request.CacheParameterGroupName = cmdletContext.CacheParameterGroupName;
            }
            if (cmdletContext.Engine != null)
            {
                request.Engine = cmdletContext.Engine;
            }
            if (cmdletContext.EngineVersion != null)
            {
                request.EngineVersion = cmdletContext.EngineVersion;
            }
            if (cmdletContext.GlobalReplicationGroupDescription != null)
            {
                request.GlobalReplicationGroupDescription = cmdletContext.GlobalReplicationGroupDescription;
            }
            if (cmdletContext.GlobalReplicationGroupId != null)
            {
                request.GlobalReplicationGroupId = cmdletContext.GlobalReplicationGroupId;
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
        
        private Amazon.ElastiCache.Model.ModifyGlobalReplicationGroupResponse CallAWSServiceOperation(IAmazonElastiCache client, Amazon.ElastiCache.Model.ModifyGlobalReplicationGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon ElastiCache", "ModifyGlobalReplicationGroup");
            try
            {
                #if DESKTOP
                return client.ModifyGlobalReplicationGroup(request);
                #elif CORECLR
                return client.ModifyGlobalReplicationGroupAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? ApplyImmediately { get; set; }
            public System.Boolean? AutomaticFailoverEnabled { get; set; }
            public System.String CacheNodeType { get; set; }
            public System.String CacheParameterGroupName { get; set; }
            public System.String Engine { get; set; }
            public System.String EngineVersion { get; set; }
            public System.String GlobalReplicationGroupDescription { get; set; }
            public System.String GlobalReplicationGroupId { get; set; }
            public System.Func<Amazon.ElastiCache.Model.ModifyGlobalReplicationGroupResponse, EditECGlobalReplicationGroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.GlobalReplicationGroup;
        }
        
    }
}
