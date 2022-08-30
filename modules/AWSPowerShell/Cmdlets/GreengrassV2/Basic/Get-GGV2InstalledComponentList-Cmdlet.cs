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
using Amazon.GreengrassV2;
using Amazon.GreengrassV2.Model;

namespace Amazon.PowerShell.Cmdlets.GGV2
{
    /// <summary>
    /// Retrieves a paginated list of the components that a Greengrass core device runs. By
    /// default, this list doesn't include components that are deployed as dependencies of
    /// other components. To include dependencies in the response, set the <code>topologyFilter</code>
    /// parameter to <code>ALL</code>.
    /// 
    ///  <note><para>
    /// IoT Greengrass relies on individual devices to send status updates to the Amazon Web
    /// Services Cloud. If the IoT Greengrass Core software isn't running on the device, or
    /// if device isn't connected to the Amazon Web Services Cloud, then the reported status
    /// of that device might not reflect its current status. The status timestamp indicates
    /// when the device status was last updated.
    /// </para><para>
    /// Core devices send status updates at the following times:
    /// </para><ul><li><para>
    /// When the IoT Greengrass Core software starts
    /// </para></li><li><para>
    /// When the core device receives a deployment from the Amazon Web Services Cloud
    /// </para></li><li><para>
    /// When the status of any component on the core device becomes <code>BROKEN</code></para></li><li><para>
    /// At a <a href="https://docs.aws.amazon.com/greengrass/v2/developerguide/greengrass-nucleus-component.html#greengrass-nucleus-component-configuration-fss">regular
    /// interval that you can configure</a>, which defaults to 24 hours
    /// </para></li><li><para>
    /// For IoT Greengrass Core v2.7.0, the core device sends status updates upon local deployment
    /// and cloud deployment
    /// </para></li></ul></note>
    /// </summary>
    [Cmdlet("Get", "GGV2InstalledComponentList")]
    [OutputType("Amazon.GreengrassV2.Model.InstalledComponent")]
    [AWSCmdlet("Calls the AWS GreengrassV2 ListInstalledComponents API operation.", Operation = new[] {"ListInstalledComponents"}, SelectReturnType = typeof(Amazon.GreengrassV2.Model.ListInstalledComponentsResponse))]
    [AWSCmdletOutput("Amazon.GreengrassV2.Model.InstalledComponent or Amazon.GreengrassV2.Model.ListInstalledComponentsResponse",
        "This cmdlet returns a collection of Amazon.GreengrassV2.Model.InstalledComponent objects.",
        "The service call response (type Amazon.GreengrassV2.Model.ListInstalledComponentsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetGGV2InstalledComponentListCmdlet : AmazonGreengrassV2ClientCmdlet, IExecutor
    {
        
        #region Parameter CoreDeviceThingName
        /// <summary>
        /// <para>
        /// <para>The name of the core device. This is also the name of the IoT thing.</para>
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
        public System.String CoreDeviceThingName { get; set; }
        #endregion
        
        #region Parameter TopologyFilter
        /// <summary>
        /// <para>
        /// <para>The filter for the list of components. Choose from the following options:</para><ul><li><para><code>ALL</code> – The list includes all components installed on the core device.</para></li><li><para><code>ROOT</code> – The list includes only <i>root</i> components, which are components
        /// that you specify in a deployment. When you choose this option, the list doesn't include
        /// components that the core device installs as dependencies of other components.</para></li></ul><para>Default: <code>ROOT</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.GreengrassV2.InstalledComponentTopologyFilter")]
        public Amazon.GreengrassV2.InstalledComponentTopologyFilter TopologyFilter { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to be returned per paginated request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token to be used for the next set of paginated results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'InstalledComponents'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GreengrassV2.Model.ListInstalledComponentsResponse).
        /// Specifying the name of a property of type Amazon.GreengrassV2.Model.ListInstalledComponentsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "InstalledComponents";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the CoreDeviceThingName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^CoreDeviceThingName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^CoreDeviceThingName' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.GreengrassV2.Model.ListInstalledComponentsResponse, GetGGV2InstalledComponentListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.CoreDeviceThingName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.CoreDeviceThingName = this.CoreDeviceThingName;
            #if MODULAR
            if (this.CoreDeviceThingName == null && ParameterWasBound(nameof(this.CoreDeviceThingName)))
            {
                WriteWarning("You are passing $null as a value for parameter CoreDeviceThingName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.TopologyFilter = this.TopologyFilter;
            
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
            var request = new Amazon.GreengrassV2.Model.ListInstalledComponentsRequest();
            
            if (cmdletContext.CoreDeviceThingName != null)
            {
                request.CoreDeviceThingName = cmdletContext.CoreDeviceThingName;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.TopologyFilter != null)
            {
                request.TopologyFilter = cmdletContext.TopologyFilter;
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
        
        private Amazon.GreengrassV2.Model.ListInstalledComponentsResponse CallAWSServiceOperation(IAmazonGreengrassV2 client, Amazon.GreengrassV2.Model.ListInstalledComponentsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS GreengrassV2", "ListInstalledComponents");
            try
            {
                #if DESKTOP
                return client.ListInstalledComponents(request);
                #elif CORECLR
                return client.ListInstalledComponentsAsync(request).GetAwaiter().GetResult();
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
            public System.String CoreDeviceThingName { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public Amazon.GreengrassV2.InstalledComponentTopologyFilter TopologyFilter { get; set; }
            public System.Func<Amazon.GreengrassV2.Model.ListInstalledComponentsResponse, GetGGV2InstalledComponentListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.InstalledComponents;
        }
        
    }
}
