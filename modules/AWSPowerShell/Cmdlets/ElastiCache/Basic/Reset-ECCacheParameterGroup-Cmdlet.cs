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
    /// Modifies the parameters of a cache parameter group to the engine or system default
    /// value. You can reset specific parameters by submitting a list of parameter names.
    /// To reset the entire cache parameter group, specify the <c>ResetAllParameters</c> and
    /// <c>CacheParameterGroupName</c> parameters.
    /// </summary>
    [Cmdlet("Reset", "ECCacheParameterGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon ElastiCache ResetCacheParameterGroup API operation.", Operation = new[] {"ResetCacheParameterGroup"}, SelectReturnType = typeof(Amazon.ElastiCache.Model.ResetCacheParameterGroupResponse))]
    [AWSCmdletOutput("System.String or Amazon.ElastiCache.Model.ResetCacheParameterGroupResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.ElastiCache.Model.ResetCacheParameterGroupResponse) can be returned by specifying '-Select *'."
    )]
    public partial class ResetECCacheParameterGroupCmdlet : AmazonElastiCacheClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CacheParameterGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the cache parameter group to reset.</para>
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
        
        #region Parameter ParameterNameValue
        /// <summary>
        /// <para>
        /// <para>An array of parameter names to reset to their default values. If <c>ResetAllParameters</c>
        /// is <c>true</c>, do not use <c>ParameterNameValues</c>. If <c>ResetAllParameters</c>
        /// is <c>false</c>, you must specify the name of at least one parameter to reset.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ParameterNameValues")]
        public Amazon.ElastiCache.Model.ParameterNameValue[] ParameterNameValue { get; set; }
        #endregion
        
        #region Parameter ResetAllParameter
        /// <summary>
        /// <para>
        /// <para>If <c>true</c>, all parameters in the cache parameter group are reset to their default
        /// values. If <c>false</c>, only the parameters listed by <c>ParameterNameValues</c>
        /// are reset to their default values.</para><para>Valid values: <c>true</c> | <c>false</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResetAllParameters")]
        public System.Boolean? ResetAllParameter { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'CacheParameterGroupName'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElastiCache.Model.ResetCacheParameterGroupResponse).
        /// Specifying the name of a property of type Amazon.ElastiCache.Model.ResetCacheParameterGroupResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "CacheParameterGroupName";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Reset-ECCacheParameterGroup (ResetCacheParameterGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ElastiCache.Model.ResetCacheParameterGroupResponse, ResetECCacheParameterGroupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CacheParameterGroupName = this.CacheParameterGroupName;
            #if MODULAR
            if (this.CacheParameterGroupName == null && ParameterWasBound(nameof(this.CacheParameterGroupName)))
            {
                WriteWarning("You are passing $null as a value for parameter CacheParameterGroupName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ParameterNameValue != null)
            {
                context.ParameterNameValue = new List<Amazon.ElastiCache.Model.ParameterNameValue>(this.ParameterNameValue);
            }
            context.ResetAllParameter = this.ResetAllParameter;
            
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
            var request = new Amazon.ElastiCache.Model.ResetCacheParameterGroupRequest();
            
            if (cmdletContext.CacheParameterGroupName != null)
            {
                request.CacheParameterGroupName = cmdletContext.CacheParameterGroupName;
            }
            if (cmdletContext.ParameterNameValue != null)
            {
                request.ParameterNameValues = cmdletContext.ParameterNameValue;
            }
            if (cmdletContext.ResetAllParameter != null)
            {
                request.ResetAllParameters = cmdletContext.ResetAllParameter.Value;
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
        
        private Amazon.ElastiCache.Model.ResetCacheParameterGroupResponse CallAWSServiceOperation(IAmazonElastiCache client, Amazon.ElastiCache.Model.ResetCacheParameterGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon ElastiCache", "ResetCacheParameterGroup");
            try
            {
                #if DESKTOP
                return client.ResetCacheParameterGroup(request);
                #elif CORECLR
                return client.ResetCacheParameterGroupAsync(request).GetAwaiter().GetResult();
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
            public System.String CacheParameterGroupName { get; set; }
            public List<Amazon.ElastiCache.Model.ParameterNameValue> ParameterNameValue { get; set; }
            public System.Boolean? ResetAllParameter { get; set; }
            public System.Func<Amazon.ElastiCache.Model.ResetCacheParameterGroupResponse, ResetECCacheParameterGroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.CacheParameterGroupName;
        }
        
    }
}
