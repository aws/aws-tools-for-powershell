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
using Amazon.ElastiCache;
using Amazon.ElastiCache.Model;

namespace Amazon.PowerShell.Cmdlets.EC
{
    /// <summary>
    /// Creates a new Amazon ElastiCache cache parameter group. An ElastiCache cache parameter
    /// group is a collection of parameters and their values that are applied to all of the
    /// nodes in any cluster or replication group using the CacheParameterGroup.
    /// 
    ///  
    /// <para>
    /// A newly created CacheParameterGroup is an exact duplicate of the default parameter
    /// group for the CacheParameterGroupFamily. To customize the newly created CacheParameterGroup
    /// you can change the values of specific parameters. For more information, see:
    /// </para><ul><li><para><a href="https://docs.aws.amazon.com/AmazonElastiCache/latest/APIReference/API_ModifyCacheParameterGroup.html">ModifyCacheParameterGroup</a>
    /// in the ElastiCache API Reference.
    /// </para></li><li><para><a href="https://docs.aws.amazon.com/AmazonElastiCache/latest/red-ug/ParameterGroups.html">Parameters
    /// and Parameter Groups</a> in the ElastiCache User Guide.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("New", "ECCacheParameterGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ElastiCache.Model.CacheParameterGroup")]
    [AWSCmdlet("Calls the Amazon ElastiCache CreateCacheParameterGroup API operation.", Operation = new[] {"CreateCacheParameterGroup"}, SelectReturnType = typeof(Amazon.ElastiCache.Model.CreateCacheParameterGroupResponse))]
    [AWSCmdletOutput("Amazon.ElastiCache.Model.CacheParameterGroup or Amazon.ElastiCache.Model.CreateCacheParameterGroupResponse",
        "This cmdlet returns an Amazon.ElastiCache.Model.CacheParameterGroup object.",
        "The service call response (type Amazon.ElastiCache.Model.CreateCacheParameterGroupResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewECCacheParameterGroupCmdlet : AmazonElastiCacheClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CacheParameterGroupFamily
        /// <summary>
        /// <para>
        /// <para>The name of the cache parameter group family that the cache parameter group can be
        /// used with.</para><para>Valid values are: <c>memcached1.4</c> | <c>memcached1.5</c> | <c>memcached1.6</c>
        /// | <c>redis2.6</c> | <c>redis2.8</c> | <c>redis3.2</c> | <c>redis4.0</c> | <c>redis5.0</c>
        /// | <c>redis6.x</c> | <c>redis7</c></para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String CacheParameterGroupFamily { get; set; }
        #endregion
        
        #region Parameter CacheParameterGroupName
        /// <summary>
        /// <para>
        /// <para>A user-specified name for the cache parameter group.</para>
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
        public System.String CacheParameterGroupName { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A user-specified description for the cache parameter group.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of tags to be added to this resource. A tag is a key-value pair. A tag key
        /// must be accompanied by a tag value, although null is accepted.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.ElastiCache.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'CacheParameterGroup'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElastiCache.Model.CreateCacheParameterGroupResponse).
        /// Specifying the name of a property of type Amazon.ElastiCache.Model.CreateCacheParameterGroupResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "CacheParameterGroup";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.CacheParameterGroupName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-ECCacheParameterGroup (CreateCacheParameterGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ElastiCache.Model.CreateCacheParameterGroupResponse, NewECCacheParameterGroupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CacheParameterGroupFamily = this.CacheParameterGroupFamily;
            #if MODULAR
            if (this.CacheParameterGroupFamily == null && ParameterWasBound(nameof(this.CacheParameterGroupFamily)))
            {
                WriteWarning("You are passing $null as a value for parameter CacheParameterGroupFamily which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CacheParameterGroupName = this.CacheParameterGroupName;
            #if MODULAR
            if (this.CacheParameterGroupName == null && ParameterWasBound(nameof(this.CacheParameterGroupName)))
            {
                WriteWarning("You are passing $null as a value for parameter CacheParameterGroupName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Description = this.Description;
            #if MODULAR
            if (this.Description == null && ParameterWasBound(nameof(this.Description)))
            {
                WriteWarning("You are passing $null as a value for parameter Description which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.ElastiCache.Model.Tag>(this.Tag);
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
            var request = new Amazon.ElastiCache.Model.CreateCacheParameterGroupRequest();
            
            if (cmdletContext.CacheParameterGroupFamily != null)
            {
                request.CacheParameterGroupFamily = cmdletContext.CacheParameterGroupFamily;
            }
            if (cmdletContext.CacheParameterGroupName != null)
            {
                request.CacheParameterGroupName = cmdletContext.CacheParameterGroupName;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
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
        
        private Amazon.ElastiCache.Model.CreateCacheParameterGroupResponse CallAWSServiceOperation(IAmazonElastiCache client, Amazon.ElastiCache.Model.CreateCacheParameterGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon ElastiCache", "CreateCacheParameterGroup");
            try
            {
                #if DESKTOP
                return client.CreateCacheParameterGroup(request);
                #elif CORECLR
                return client.CreateCacheParameterGroupAsync(request).GetAwaiter().GetResult();
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
            public System.String CacheParameterGroupFamily { get; set; }
            public System.String CacheParameterGroupName { get; set; }
            public System.String Description { get; set; }
            public List<Amazon.ElastiCache.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.ElastiCache.Model.CreateCacheParameterGroupResponse, NewECCacheParameterGroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.CacheParameterGroup;
        }
        
    }
}
