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
using Amazon.CloudFormation;
using Amazon.CloudFormation.Model;

namespace Amazon.PowerShell.Cmdlets.CFN
{
    /// <summary>
    /// Returns configuration data for the specified CloudFormation extensions, from the CloudFormation
    /// registry for the account and region.
    /// 
    ///  
    /// <para>
    /// For more information, see <a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/registry-register.html#registry-set-configuration">Configuring
    /// extensions at the account level</a> in the <i>CloudFormation User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "CFNDescribeTypeConfiguration")]
    [OutputType("Amazon.CloudFormation.Model.BatchDescribeTypeConfigurationsResponse")]
    [AWSCmdlet("Calls the AWS CloudFormation BatchDescribeTypeConfigurations API operation.", Operation = new[] {"BatchDescribeTypeConfigurations"}, SelectReturnType = typeof(Amazon.CloudFormation.Model.BatchDescribeTypeConfigurationsResponse))]
    [AWSCmdletOutput("Amazon.CloudFormation.Model.BatchDescribeTypeConfigurationsResponse",
        "This cmdlet returns an Amazon.CloudFormation.Model.BatchDescribeTypeConfigurationsResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetCFNDescribeTypeConfigurationCmdlet : AmazonCloudFormationClientCmdlet, IExecutor
    {
        
        #region Parameter TypeConfigurationIdentifier
        /// <summary>
        /// <para>
        /// <para>The list of identifiers for the desired extension configurations.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("TypeConfigurationIdentifiers")]
        public Amazon.CloudFormation.Model.TypeConfigurationIdentifier[] TypeConfigurationIdentifier { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudFormation.Model.BatchDescribeTypeConfigurationsResponse).
        /// Specifying the name of a property of type Amazon.CloudFormation.Model.BatchDescribeTypeConfigurationsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
                context.Select = CreateSelectDelegate<Amazon.CloudFormation.Model.BatchDescribeTypeConfigurationsResponse, GetCFNDescribeTypeConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.TypeConfigurationIdentifier != null)
            {
                context.TypeConfigurationIdentifier = new List<Amazon.CloudFormation.Model.TypeConfigurationIdentifier>(this.TypeConfigurationIdentifier);
            }
            #if MODULAR
            if (this.TypeConfigurationIdentifier == null && ParameterWasBound(nameof(this.TypeConfigurationIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter TypeConfigurationIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.CloudFormation.Model.BatchDescribeTypeConfigurationsRequest();
            
            if (cmdletContext.TypeConfigurationIdentifier != null)
            {
                request.TypeConfigurationIdentifiers = cmdletContext.TypeConfigurationIdentifier;
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
        
        private Amazon.CloudFormation.Model.BatchDescribeTypeConfigurationsResponse CallAWSServiceOperation(IAmazonCloudFormation client, Amazon.CloudFormation.Model.BatchDescribeTypeConfigurationsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CloudFormation", "BatchDescribeTypeConfigurations");
            try
            {
                #if DESKTOP
                return client.BatchDescribeTypeConfigurations(request);
                #elif CORECLR
                return client.BatchDescribeTypeConfigurationsAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.CloudFormation.Model.TypeConfigurationIdentifier> TypeConfigurationIdentifier { get; set; }
            public System.Func<Amazon.CloudFormation.Model.BatchDescribeTypeConfigurationsResponse, GetCFNDescribeTypeConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
