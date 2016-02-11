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
using Amazon.Lambda;
using Amazon.Lambda.Model;

namespace Amazon.PowerShell.Cmdlets.LM
{
    /// <summary>
    /// Returns a list of your Lambda functions. For each function, the response includes
    /// the function configuration information. You must use <a>GetFunction</a> to retrieve
    /// the code for your function.
    /// 
    ///  
    /// <para>
    /// This operation requires permission for the <code>lambda:ListFunctions</code> action.
    /// </para><para>
    /// If you are using versioning feature, the response returns list of $LATEST versions
    /// of your functions. For information about the versioning feature, see <a href="http://docs.aws.amazon.com/lambda/latest/dg/versioning-aliases.html">AWS
    /// Lambda Function Versioning and Aliases</a>. 
    /// </para>
    /// </summary>
    [Cmdlet("Get", "LMFunctions")]
    [OutputType("Amazon.Lambda.Model.FunctionConfiguration")]
    [AWSCmdlet("Invokes the ListFunctions operation against Amazon Lambda.", Operation = new[] {"ListFunctions"})]
    [AWSCmdletOutput("Amazon.Lambda.Model.FunctionConfiguration",
        "This cmdlet returns a collection of FunctionConfiguration objects.",
        "The service call response (type Amazon.Lambda.Model.ListFunctionsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextMarker (type System.String)"
    )]
    public class GetLMFunctionsCmdlet : AmazonLambdaClientCmdlet, IExecutor
    {
        
        #region Parameter Marker
        /// <summary>
        /// <para>
        /// <para>Optional string. An opaque pagination token returned from a previous <code>ListFunctions</code>
        /// operation. If present, indicates where to continue the listing. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Marker { get; set; }
        #endregion
        
        #region Parameter MaxItem
        /// <summary>
        /// <para>
        /// <para>Optional integer. Specifies the maximum number of AWS Lambda functions to return in
        /// response. This parameter value must be greater than 0.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxItems")]
        public System.Int32 MaxItem { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.Marker = this.Marker;
            if (ParameterWasBound("MaxItem"))
                context.MaxItems = this.MaxItem;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.Lambda.Model.ListFunctionsRequest();
            
            if (cmdletContext.Marker != null)
            {
                request.Marker = cmdletContext.Marker;
            }
            if (cmdletContext.MaxItems != null)
            {
                request.MaxItems = cmdletContext.MaxItems.Value;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.ListFunctions(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Functions;
                notes = new Dictionary<string, object>();
                notes["NextMarker"] = response.NextMarker;
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String Marker { get; set; }
            public System.Int32? MaxItems { get; set; }
        }
        
    }
}
