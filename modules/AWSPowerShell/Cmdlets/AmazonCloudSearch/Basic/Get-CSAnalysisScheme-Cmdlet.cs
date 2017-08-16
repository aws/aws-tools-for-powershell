/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.CloudSearch;
using Amazon.CloudSearch.Model;

namespace Amazon.PowerShell.Cmdlets.CS
{
    /// <summary>
    /// Gets the analysis schemes configured for a domain. An analysis scheme defines language-specific
    /// text processing options for a <code>text</code> field. Can be limited to specific
    /// analysis schemes by name. By default, shows all analysis schemes and includes any
    /// pending changes to the configuration. Set the <code>Deployed</code> option to <code>true</code>
    /// to show the active configuration and exclude pending changes. For more information,
    /// see <a href="http://docs.aws.amazon.com/cloudsearch/latest/developerguide/configuring-analysis-schemes.html" target="_blank">Configuring Analysis Schemes</a> in the <i>Amazon CloudSearch Developer
    /// Guide</i>.
    /// </summary>
    [Cmdlet("Get", "CSAnalysisScheme")]
    [OutputType("Amazon.CloudSearch.Model.AnalysisSchemeStatus")]
    [AWSCmdlet("Invokes the DescribeAnalysisSchemes operation against Amazon CloudSearch.", Operation = new[] {"DescribeAnalysisSchemes"}, LegacyAlias="Get-CSAnalysisSchemes")]
    [AWSCmdletOutput("Amazon.CloudSearch.Model.AnalysisSchemeStatus",
        "This cmdlet returns a collection of AnalysisSchemeStatus objects.",
        "The service call response (type Amazon.CloudSearch.Model.DescribeAnalysisSchemesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetCSAnalysisSchemeCmdlet : AmazonCloudSearchClientCmdlet, IExecutor
    {
        
        #region Parameter AnalysisSchemeName
        /// <summary>
        /// <para>
        /// <para>The analysis schemes you want to describe.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("AnalysisSchemeNames")]
        public System.String[] AnalysisSchemeName { get; set; }
        #endregion
        
        #region Parameter Deployed
        /// <summary>
        /// <para>
        /// <para>Whether to display the deployed configuration (<code>true</code>) or include any pending
        /// changes (<code>false</code>). Defaults to <code>false</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean Deployed { get; set; }
        #endregion
        
        #region Parameter DomainName
        /// <summary>
        /// <para>
        /// <para>The name of the domain you want to describe.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String DomainName { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (this.AnalysisSchemeName != null)
            {
                context.AnalysisSchemeNames = new List<System.String>(this.AnalysisSchemeName);
            }
            if (ParameterWasBound("Deployed"))
                context.Deployed = this.Deployed;
            context.DomainName = this.DomainName;
            
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
            var request = new Amazon.CloudSearch.Model.DescribeAnalysisSchemesRequest();
            
            if (cmdletContext.AnalysisSchemeNames != null)
            {
                request.AnalysisSchemeNames = cmdletContext.AnalysisSchemeNames;
            }
            if (cmdletContext.Deployed != null)
            {
                request.Deployed = cmdletContext.Deployed.Value;
            }
            if (cmdletContext.DomainName != null)
            {
                request.DomainName = cmdletContext.DomainName;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.AnalysisSchemes;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
        
        private Amazon.CloudSearch.Model.DescribeAnalysisSchemesResponse CallAWSServiceOperation(IAmazonCloudSearch client, Amazon.CloudSearch.Model.DescribeAnalysisSchemesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudSearch", "DescribeAnalysisSchemes");
            try
            {
                #if DESKTOP
                return client.DescribeAnalysisSchemes(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.DescribeAnalysisSchemesAsync(request);
                return task.Result;
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
            public List<System.String> AnalysisSchemeNames { get; set; }
            public System.Boolean? Deployed { get; set; }
            public System.String DomainName { get; set; }
        }
        
    }
}
