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
using Amazon.Route53;
using Amazon.Route53.Model;

namespace Amazon.PowerShell.Cmdlets.R53
{
    /// <summary>
    
    /// </summary>
    [Cmdlet("Test", "R53DNSAnswer")]
    [OutputType("Amazon.Route53.Model.TestDNSAnswerResponse")]
    [AWSCmdlet("Invokes the TestDNSAnswer operation against Amazon Route 53.", Operation = new[] {"TestDNSAnswer"})]
    [AWSCmdletOutput("Amazon.Route53.Model.TestDNSAnswerResponse",
        "This cmdlet returns a Amazon.Route53.Model.TestDNSAnswerResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class TestR53DNSAnswerCmdlet : AmazonRoute53ClientCmdlet, IExecutor
    {
        
        #region Parameter EDNS0ClientSubnetIP
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String EDNS0ClientSubnetIP { get; set; }
        #endregion
        
        #region Parameter EDNS0ClientSubnetMask
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String EDNS0ClientSubnetMask { get; set; }
        #endregion
        
        #region Parameter HostedZoneId
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String HostedZoneId { get; set; }
        #endregion
        
        #region Parameter RecordName
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String RecordName { get; set; }
        #endregion
        
        #region Parameter RecordType
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.Route53.RRType")]
        public Amazon.Route53.RRType RecordType { get; set; }
        #endregion
        
        #region Parameter ResolverIP
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ResolverIP { get; set; }
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
            
            context.HostedZoneId = this.HostedZoneId;
            context.RecordName = this.RecordName;
            context.RecordType = this.RecordType;
            context.ResolverIP = this.ResolverIP;
            context.EDNS0ClientSubnetIP = this.EDNS0ClientSubnetIP;
            context.EDNS0ClientSubnetMask = this.EDNS0ClientSubnetMask;
            
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
            var request = new Amazon.Route53.Model.TestDNSAnswerRequest();
            
            if (cmdletContext.HostedZoneId != null)
            {
                request.HostedZoneId = cmdletContext.HostedZoneId;
            }
            if (cmdletContext.RecordName != null)
            {
                request.RecordName = cmdletContext.RecordName;
            }
            if (cmdletContext.RecordType != null)
            {
                request.RecordType = cmdletContext.RecordType;
            }
            if (cmdletContext.ResolverIP != null)
            {
                request.ResolverIP = cmdletContext.ResolverIP;
            }
            if (cmdletContext.EDNS0ClientSubnetIP != null)
            {
                request.EDNS0ClientSubnetIP = cmdletContext.EDNS0ClientSubnetIP;
            }
            if (cmdletContext.EDNS0ClientSubnetMask != null)
            {
                request.EDNS0ClientSubnetMask = cmdletContext.EDNS0ClientSubnetMask;
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
        
        private static Amazon.Route53.Model.TestDNSAnswerResponse CallAWSServiceOperation(IAmazonRoute53 client, Amazon.Route53.Model.TestDNSAnswerRequest request)
        {
            #if DESKTOP
            return client.TestDNSAnswer(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.TestDNSAnswerAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String HostedZoneId { get; set; }
            public System.String RecordName { get; set; }
            public Amazon.Route53.RRType RecordType { get; set; }
            public System.String ResolverIP { get; set; }
            public System.String EDNS0ClientSubnetIP { get; set; }
            public System.String EDNS0ClientSubnetMask { get; set; }
        }
        
    }
}
