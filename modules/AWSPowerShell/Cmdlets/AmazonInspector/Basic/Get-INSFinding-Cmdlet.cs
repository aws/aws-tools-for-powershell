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
using Amazon.Inspector;
using Amazon.Inspector.Model;

namespace Amazon.PowerShell.Cmdlets.INS
{
    /// <summary>
    /// Describes the findings that are specified by the ARNs of the findings.
    /// </summary>
    [Cmdlet("Get", "INSFinding")]
    [OutputType("Amazon.Inspector.Model.DescribeFindingsResponse")]
    [AWSCmdlet("Calls the Amazon Inspector DescribeFindings API operation.", Operation = new[] {"DescribeFindings"})]
    [AWSCmdletOutput("Amazon.Inspector.Model.DescribeFindingsResponse",
        "This cmdlet returns a Amazon.Inspector.Model.DescribeFindingsResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetINSFindingCmdlet : AmazonInspectorClientCmdlet, IExecutor
    {
        
        #region Parameter FindingArn
        /// <summary>
        /// <para>
        /// <para>The ARN that specifies the finding that you want to describe.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("FindingArns")]
        public System.String[] FindingArn { get; set; }
        #endregion
        
        #region Parameter Locale
        /// <summary>
        /// <para>
        /// <para>The locale into which you want to translate a finding description, recommendation,
        /// and the short description that identifies the finding.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.Inspector.Locale")]
        public Amazon.Inspector.Locale Locale { get; set; }
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
            
            if (this.FindingArn != null)
            {
                context.FindingArns = new List<System.String>(this.FindingArn);
            }
            context.Locale = this.Locale;
            
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
            var request = new Amazon.Inspector.Model.DescribeFindingsRequest();
            
            if (cmdletContext.FindingArns != null)
            {
                request.FindingArns = cmdletContext.FindingArns;
            }
            if (cmdletContext.Locale != null)
            {
                request.Locale = cmdletContext.Locale;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
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
        
        private Amazon.Inspector.Model.DescribeFindingsResponse CallAWSServiceOperation(IAmazonInspector client, Amazon.Inspector.Model.DescribeFindingsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Inspector", "DescribeFindings");
            try
            {
                #if DESKTOP
                return client.DescribeFindings(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.DescribeFindingsAsync(request);
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
            public List<System.String> FindingArns { get; set; }
            public Amazon.Inspector.Locale Locale { get; set; }
        }
        
    }
}
