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
using Amazon.OpsWorks;
using Amazon.OpsWorks.Model;

namespace Amazon.PowerShell.Cmdlets.OPS
{
    /// <summary>
    /// Describes the available OpsWorks Stacks agent versions. You must specify a stack ID
    /// or a configuration manager. <c>DescribeAgentVersions</c> returns a list of available
    /// agent versions for the specified stack or configuration manager.
    /// </summary>
    [Cmdlet("Get", "OPSAgentVersion")]
    [OutputType("Amazon.OpsWorks.Model.AgentVersion")]
    [AWSCmdlet("Calls the AWS OpsWorks DescribeAgentVersions API operation.", Operation = new[] {"DescribeAgentVersions"}, SelectReturnType = typeof(Amazon.OpsWorks.Model.DescribeAgentVersionsResponse))]
    [AWSCmdletOutput("Amazon.OpsWorks.Model.AgentVersion or Amazon.OpsWorks.Model.DescribeAgentVersionsResponse",
        "This cmdlet returns a collection of Amazon.OpsWorks.Model.AgentVersion objects.",
        "The service call response (type Amazon.OpsWorks.Model.DescribeAgentVersionsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetOPSAgentVersionCmdlet : AmazonOpsWorksClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ConfigurationManager_Name
        /// <summary>
        /// <para>
        /// <para>The name. This parameter must be set to <c>Chef</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConfigurationManager_Name { get; set; }
        #endregion
        
        #region Parameter StackId
        /// <summary>
        /// <para>
        /// <para>The stack ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String StackId { get; set; }
        #endregion
        
        #region Parameter ConfigurationManager_Version
        /// <summary>
        /// <para>
        /// <para>The Chef version. This parameter must be set to 12, 11.10, or 11.4 for Linux stacks,
        /// and to 12.2 for Windows stacks. The default value for Linux stacks is 12.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConfigurationManager_Version { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AgentVersions'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.OpsWorks.Model.DescribeAgentVersionsResponse).
        /// Specifying the name of a property of type Amazon.OpsWorks.Model.DescribeAgentVersionsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AgentVersions";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.OpsWorks.Model.DescribeAgentVersionsResponse, GetOPSAgentVersionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ConfigurationManager_Name = this.ConfigurationManager_Name;
            context.ConfigurationManager_Version = this.ConfigurationManager_Version;
            context.StackId = this.StackId;
            
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
            var request = new Amazon.OpsWorks.Model.DescribeAgentVersionsRequest();
            
            
             // populate ConfigurationManager
            var requestConfigurationManagerIsNull = true;
            request.ConfigurationManager = new Amazon.OpsWorks.Model.StackConfigurationManager();
            System.String requestConfigurationManager_configurationManager_Name = null;
            if (cmdletContext.ConfigurationManager_Name != null)
            {
                requestConfigurationManager_configurationManager_Name = cmdletContext.ConfigurationManager_Name;
            }
            if (requestConfigurationManager_configurationManager_Name != null)
            {
                request.ConfigurationManager.Name = requestConfigurationManager_configurationManager_Name;
                requestConfigurationManagerIsNull = false;
            }
            System.String requestConfigurationManager_configurationManager_Version = null;
            if (cmdletContext.ConfigurationManager_Version != null)
            {
                requestConfigurationManager_configurationManager_Version = cmdletContext.ConfigurationManager_Version;
            }
            if (requestConfigurationManager_configurationManager_Version != null)
            {
                request.ConfigurationManager.Version = requestConfigurationManager_configurationManager_Version;
                requestConfigurationManagerIsNull = false;
            }
             // determine if request.ConfigurationManager should be set to null
            if (requestConfigurationManagerIsNull)
            {
                request.ConfigurationManager = null;
            }
            if (cmdletContext.StackId != null)
            {
                request.StackId = cmdletContext.StackId;
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
        
        private Amazon.OpsWorks.Model.DescribeAgentVersionsResponse CallAWSServiceOperation(IAmazonOpsWorks client, Amazon.OpsWorks.Model.DescribeAgentVersionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS OpsWorks", "DescribeAgentVersions");
            try
            {
                #if DESKTOP
                return client.DescribeAgentVersions(request);
                #elif CORECLR
                return client.DescribeAgentVersionsAsync(request).GetAwaiter().GetResult();
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
            public System.String ConfigurationManager_Name { get; set; }
            public System.String ConfigurationManager_Version { get; set; }
            public System.String StackId { get; set; }
            public System.Func<Amazon.OpsWorks.Model.DescribeAgentVersionsResponse, GetOPSAgentVersionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AgentVersions;
        }
        
    }
}
