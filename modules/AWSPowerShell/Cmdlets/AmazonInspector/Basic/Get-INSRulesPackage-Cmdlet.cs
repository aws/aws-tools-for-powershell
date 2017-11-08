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
    /// Describes the rules packages that are specified by the ARNs of the rules packages.
    /// </summary>
    [Cmdlet("Get", "INSRulesPackage")]
    [OutputType("Amazon.Inspector.Model.DescribeRulesPackagesResponse")]
    [AWSCmdlet("Calls the Amazon Inspector DescribeRulesPackages API operation.", Operation = new[] {"DescribeRulesPackages"})]
    [AWSCmdletOutput("Amazon.Inspector.Model.DescribeRulesPackagesResponse",
        "This cmdlet returns a Amazon.Inspector.Model.DescribeRulesPackagesResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetINSRulesPackageCmdlet : AmazonInspectorClientCmdlet, IExecutor
    {
        
        #region Parameter Locale
        /// <summary>
        /// <para>
        /// <para>The locale that you want to translate a rules package description into.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.Inspector.Locale")]
        public Amazon.Inspector.Locale Locale { get; set; }
        #endregion
        
        #region Parameter RulesPackageArn
        /// <summary>
        /// <para>
        /// <para>The ARN that specifies the rules package that you want to describe.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("RulesPackageArns")]
        public System.String[] RulesPackageArn { get; set; }
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
            
            context.Locale = this.Locale;
            if (this.RulesPackageArn != null)
            {
                context.RulesPackageArns = new List<System.String>(this.RulesPackageArn);
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
            var request = new Amazon.Inspector.Model.DescribeRulesPackagesRequest();
            
            if (cmdletContext.Locale != null)
            {
                request.Locale = cmdletContext.Locale;
            }
            if (cmdletContext.RulesPackageArns != null)
            {
                request.RulesPackageArns = cmdletContext.RulesPackageArns;
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
        
        private Amazon.Inspector.Model.DescribeRulesPackagesResponse CallAWSServiceOperation(IAmazonInspector client, Amazon.Inspector.Model.DescribeRulesPackagesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Inspector", "DescribeRulesPackages");
            try
            {
                #if DESKTOP
                return client.DescribeRulesPackages(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.DescribeRulesPackagesAsync(request);
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
            public Amazon.Inspector.Locale Locale { get; set; }
            public List<System.String> RulesPackageArns { get; set; }
        }
        
    }
}
