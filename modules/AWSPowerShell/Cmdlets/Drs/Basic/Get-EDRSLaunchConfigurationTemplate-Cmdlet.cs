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
using Amazon.Drs;
using Amazon.Drs.Model;

namespace Amazon.PowerShell.Cmdlets.EDRS
{
    /// <summary>
    /// Lists all Launch Configuration Templates, filtered by Launch Configuration Template
    /// IDs
    /// </summary>
    [Cmdlet("Get", "EDRSLaunchConfigurationTemplate")]
    [OutputType("Amazon.Drs.Model.LaunchConfigurationTemplate")]
    [AWSCmdlet("Calls the Elastic Disaster Recovery Service DescribeLaunchConfigurationTemplates API operation.", Operation = new[] {"DescribeLaunchConfigurationTemplates"}, SelectReturnType = typeof(Amazon.Drs.Model.DescribeLaunchConfigurationTemplatesResponse))]
    [AWSCmdletOutput("Amazon.Drs.Model.LaunchConfigurationTemplate or Amazon.Drs.Model.DescribeLaunchConfigurationTemplatesResponse",
        "This cmdlet returns a collection of Amazon.Drs.Model.LaunchConfigurationTemplate objects.",
        "The service call response (type Amazon.Drs.Model.DescribeLaunchConfigurationTemplatesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetEDRSLaunchConfigurationTemplateCmdlet : AmazonDrsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter LaunchConfigurationTemplateIDs
        /// <summary>
        /// <para>
        /// <para>Request to filter Launch Configuration Templates list by Launch Configuration Template
        /// ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String[] LaunchConfigurationTemplateIDs { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>Maximum results to be returned in DescribeLaunchConfigurationTemplates.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token of the next Launch Configuration Template to retrieve.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Items'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Drs.Model.DescribeLaunchConfigurationTemplatesResponse).
        /// Specifying the name of a property of type Amazon.Drs.Model.DescribeLaunchConfigurationTemplatesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Items";
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
                context.Select = CreateSelectDelegate<Amazon.Drs.Model.DescribeLaunchConfigurationTemplatesResponse, GetEDRSLaunchConfigurationTemplateCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.LaunchConfigurationTemplateIDs != null)
            {
                context.LaunchConfigurationTemplateIDs = new List<System.String>(this.LaunchConfigurationTemplateIDs);
            }
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            
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
            var request = new Amazon.Drs.Model.DescribeLaunchConfigurationTemplatesRequest();
            
            if (cmdletContext.LaunchConfigurationTemplateIDs != null)
            {
                request.LaunchConfigurationTemplateIDs = cmdletContext.LaunchConfigurationTemplateIDs;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
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
        
        private Amazon.Drs.Model.DescribeLaunchConfigurationTemplatesResponse CallAWSServiceOperation(IAmazonDrs client, Amazon.Drs.Model.DescribeLaunchConfigurationTemplatesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Elastic Disaster Recovery Service", "DescribeLaunchConfigurationTemplates");
            try
            {
                #if DESKTOP
                return client.DescribeLaunchConfigurationTemplates(request);
                #elif CORECLR
                return client.DescribeLaunchConfigurationTemplatesAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> LaunchConfigurationTemplateIDs { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.Drs.Model.DescribeLaunchConfigurationTemplatesResponse, GetEDRSLaunchConfigurationTemplateCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Items;
        }
        
    }
}
