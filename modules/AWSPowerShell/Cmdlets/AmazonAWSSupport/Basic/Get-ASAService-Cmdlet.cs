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
using Amazon.AWSSupport;
using Amazon.AWSSupport.Model;

namespace Amazon.PowerShell.Cmdlets.ASA
{
    /// <summary>
    /// Returns the current list of AWS services and a list of service categories that applies
    /// to each one. You then use service names and categories in your <a>CreateCase</a> requests.
    /// Each AWS service has its own set of categories.
    /// 
    ///  
    /// <para>
    /// The service codes and category codes correspond to the values that are displayed in
    /// the <b>Service</b> and <b>Category</b> drop-down lists on the AWS Support Center <a href="https://console.aws.amazon.com/support/home#/case/create">Create Case</a> page.
    /// The values in those fields, however, do not necessarily match the service codes and
    /// categories returned by the <code>DescribeServices</code> request. Always use the service
    /// codes and categories obtained programmatically. This practice ensures that you always
    /// have the most recent set of service and category codes.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "ASAService")]
    [OutputType("Amazon.AWSSupport.Model.Service")]
    [AWSCmdlet("Invokes the DescribeServices operation against AWS Support API.", Operation = new[] {"DescribeServices"}, LegacyAlias="Get-ASAServices")]
    [AWSCmdletOutput("Amazon.AWSSupport.Model.Service",
        "This cmdlet returns a collection of Service objects.",
        "The service call response (type Amazon.AWSSupport.Model.DescribeServicesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetASAServiceCmdlet : AmazonAWSSupportClientCmdlet, IExecutor
    {
        
        #region Parameter Language
        /// <summary>
        /// <para>
        /// <para>The ISO 639-1 code for the language in which AWS provides support. AWS Support currently
        /// supports English ("en") and Japanese ("ja"). Language parameters must be passed explicitly
        /// for operations that take them.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        public System.String Language { get; set; }
        #endregion
        
        #region Parameter ServiceCodeList
        /// <summary>
        /// <para>
        /// <para>A JSON-formatted list of service codes available for AWS services.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String[] ServiceCodeList { get; set; }
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
            
            context.Language = this.Language;
            if (this.ServiceCodeList != null)
            {
                context.ServiceCodeList = new List<System.String>(this.ServiceCodeList);
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
            var request = new Amazon.AWSSupport.Model.DescribeServicesRequest();
            
            if (cmdletContext.Language != null)
            {
                request.Language = cmdletContext.Language;
            }
            if (cmdletContext.ServiceCodeList != null)
            {
                request.ServiceCodeList = cmdletContext.ServiceCodeList;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Services;
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
        
        private Amazon.AWSSupport.Model.DescribeServicesResponse CallAWSServiceOperation(IAmazonAWSSupport client, Amazon.AWSSupport.Model.DescribeServicesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Support API", "DescribeServices");
            try
            {
                #if DESKTOP
                return client.DescribeServices(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.DescribeServicesAsync(request);
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
            public System.String Language { get; set; }
            public List<System.String> ServiceCodeList { get; set; }
        }
        
    }
}
